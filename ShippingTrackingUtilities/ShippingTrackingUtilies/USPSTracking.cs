using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;


namespace ShippingTrackingUtilities
{
    public class USPSTracking : ITrackingFacility
    {
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

            shippingResultInString = GetTrackingInfoUSPSInString(trackingNumbers);


            MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(shippingResultInString));


            USPSTrackingResult.TrackResponse resultingMessage = new USPSTrackingResult.TrackResponse();
            USPSTrackingResultError.Error error = new USPSTrackingResultError.Error();

            if (memStream != null)
            {
                if (shippingResultInString.Contains("<Error>") && !shippingResultInString.Contains("<TrackResponse>"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(USPSTrackingResultError.Error));
                    error = (USPSTrackingResultError.Error)serializer.Deserialize(memStream);
                    shippingResult.Add(USPSTrackingResultErrorWrap(error));
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(USPSTrackingResult.TrackResponse));
                    resultingMessage = (USPSTrackingResult.TrackResponse)serializer.Deserialize(memStream);
                    shippingResult = USPSTrackingResultWrap(resultingMessage);
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


                WebClient wsClient = new WebClient();
                byte[] responseData = wsClient.DownloadData(USPS);

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
    }
}
