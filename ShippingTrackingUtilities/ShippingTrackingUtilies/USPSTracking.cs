using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;


namespace ShippingTrackingUtilities
{
    public class USPSTracking : ITrackingFacility, IDisposable
    {
        private MemoryStream _memStream;
        private WebClient _wsClient;

        public USPSTracking()
        {
        }

        public ShippingResult GetTrackingResult(string trackingNumber)
        {
            return this.GetTrackingResult(new List<string> { trackingNumber }).FirstOrDefault();
        }

        public List<ShippingResult> GetTrackingResult(List<string> trackingNumbers)
        {
            string shippingResultInString = string.Empty;
            List<ShippingResult> shippingResult = new List<ShippingResult>();

            int splitCount = 0;
            List<string> throttledTrackings = null;
            while ((throttledTrackings = trackingNumbers.Skip(splitCount).Take(10).ToList()).Count()!=0)
            {
                if (splitCount != 0)
                    System.Threading.Thread.Sleep(5000);

                splitCount += 10;

                shippingResultInString = GetTrackingInfoUSPSInString(throttledTrackings);

                _memStream = new MemoryStream(Encoding.UTF8.GetBytes(shippingResultInString));


                USPSTrackingResult.TrackResponse resultingMessage = new USPSTrackingResult.TrackResponse();
                USPSTrackingResultError.Error error = new USPSTrackingResultError.Error();

                if (_memStream != null)
                {
                    if (shippingResultInString.Contains("<Error>") && !shippingResultInString.Contains("<TrackResponse>"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(USPSTrackingResultError.Error));
                        error = (USPSTrackingResultError.Error)serializer.Deserialize(_memStream);
                        shippingResult.Add(USPSTrackingResultErrorWrap(error));
                        serializer = null;
                    }
                    else
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(USPSTrackingResult.TrackResponse));
                        resultingMessage = (USPSTrackingResult.TrackResponse)serializer.Deserialize(_memStream);
                        shippingResult = USPSTrackingResultWrap(resultingMessage);
                        serializer = null;
                    }
                }
            }
            
            return shippingResult;
        }

        private string GetTrackingInfoUSPSInString(List<string> trackingNumbers)
        {
            string USPS_USERID = ConnectionString.USPS_USERID;

            string BASEURL = "http://production.shippingapis.com/ShippingAPI.dll";

            string response = string.Empty;

            try
            {
                string USPS = BASEURL + "?API=TrackV2&XML=<TrackFieldRequest USERID=\"" + USPS_USERID + "\">";
                USPS += "<Revision>1</Revision>";
                USPS += "<ClientIp>" + "127.0.0.1" + "</ClientIp>";
                USPS += "<SourceId>" + "SV" + "</SourceId>";

                foreach (string tr in trackingNumbers)
                    USPS += "<TrackID ID=\"" + tr + "\"></TrackID>";

                USPS += "</TrackFieldRequest>";


                _wsClient = new WebClient();
                byte[] responseData = _wsClient.DownloadData(USPS);

                foreach (byte item in responseData)
                {
                    response += (char)item;
                }

                if (string.IsNullOrEmpty(response))
                    return null;

            }
            catch (Exception ex)
            {

            }

            return response;

        }

        private ShippingResult USPSTrackingResultErrorWrap(USPSTrackingResultError.Error resultingMessage)
        {
            ShippingResult shippingResult = new ShippingResult();

            shippingResult.StatusCode = "ERROR";
            shippingResult.Status = resultingMessage.Description;
            shippingResult.Message = resultingMessage.Description;

            return shippingResult;
        }
        private List<ShippingResult> USPSTrackingResultWrap(USPSTrackingResult.TrackResponse resultingMessage)
        {
            List<ShippingResult> shippingResults = new List<ShippingResult>();

            foreach (var trackingInfo in resultingMessage.Items)
            {
                ShippingResult shippingResult = new ShippingResult();

                shippingResult.ServiceType =trackingInfo.Class;
                shippingResult.StatusCode = trackingInfo.StatusCategory;
                shippingResult.Status = trackingInfo.Status;
                shippingResult.StatusSummary = trackingInfo.StatusSummary;

                if (trackingInfo.Error != null)
                {
                    if (!string.IsNullOrEmpty(trackingInfo.ToString()))
                    {
                        shippingResult.Delivered = false;
                        shippingResult.StatusCode = "Error";
                        shippingResult.Status = trackingInfo.Error.Description;
                        shippingResult.StatusSummary = trackingInfo.Error.Description;
                        shippingResult.Message = trackingInfo.Error.Description;
                    }
                }

                if (!string.IsNullOrEmpty(shippingResult.StatusCode))
                {
                    if (shippingResult.StatusCode.ToUpper().Trim() == "DELIVERED")
                    {
                        shippingResult.Delivered = true;
                        foreach (var item in trackingInfo.TrackSummary)
                        {
                            if (item.Event.ToUpper().Contains("DELIVERED"))
                            {
                                shippingResult.DeliveredDateTime = item.EventDate + " " + item.EventTime;

                                //by CJ on Oct-05-2016, to have the signatureName.
                                shippingResult.SignatureName = string.IsNullOrEmpty(item.Name) ? "" : item.Name;

                                break;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(shippingResult.StatusCode))
                {
                    if (shippingResult.StatusCode.ToUpper().Trim() == "DELIVERED")
                    {
                        shippingResult.Delivered = true;
                        foreach (var item in trackingInfo.TrackSummary)
                        {
                            if (item.Event.ToUpper().Contains("DELIVERED"))
                            {
                                shippingResult.DeliveredDateTime = item.EventDate + " " + item.EventTime;

                                //by CJ on Oct-05-2016, to have the signatureName.
                                shippingResult.SignatureName = string.IsNullOrEmpty(item.Name) ? "" : item.Name;

                                break;
                            }
                        }
                    }
                }

                if (trackingInfo.TrackDetail != null)
                {
                    if (trackingInfo.TrackDetail.Length > 0)
                    {
                        foreach (var detail in trackingInfo.TrackDetail)
                        {
                            ShippingResultEventDetail eventDetail = new ShippingResultEventDetail();
                            eventDetail.Event = detail.Event;
                            eventDetail.EventDateTime = detail.EventDate + " " + detail.EventTime;
                            eventDetail.EventAddress = detail.EventCity + " " + detail.EventState + " " + detail.EventZIPCode;
                            shippingResult.TrackingDetails.Add(eventDetail);
                        }
                    }
                }

                shippingResults.Add(shippingResult);
            }

            return shippingResults;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                if (_memStream != null)
                {
                    _memStream.Dispose();
                    _memStream = null;
                }

                if (_wsClient != null)
                {
                    _wsClient.Dispose();
                    _wsClient = null;
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~USPSTracking() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
