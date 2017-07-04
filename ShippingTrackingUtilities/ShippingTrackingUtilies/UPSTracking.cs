using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;
namespace ShippingTrackingUtilities
{
    public class UPSTracking : ITrackingFacility, IDisposable
    {
        private MemoryStream _memStream;

        public UPSTracking()
        {
        }

        public ShippingResult GetTrackingResult(string trackingNumber)
        {
            return this.GetTrackingResult(new List<string> { trackingNumber }).FirstOrDefault();
        }

        public List<ShippingResult> GetTrackingResult(List<string> trackingNumbers)
        {
            List<ShippingResult> shippingResult = new List<ShippingResult>();

            foreach (string trackingNumber in trackingNumbers)
            {
                string shippingResultInString = GetTrackingInfoUPSInString(trackingNumber);
                XmlSerializer serializer = new XmlSerializer(typeof(UPSTrackingResult.TrackResponse));
                _memStream = new MemoryStream(Encoding.UTF8.GetBytes(shippingResultInString));

                UPSTrackingResult.TrackResponse resultingMessage = new UPSTrackingResult.TrackResponse();

                if (_memStream != null)
                    resultingMessage = (UPSTrackingResult.TrackResponse)serializer.Deserialize(_memStream);

                shippingResult.Add(UPSTrackingResultWrap(resultingMessage));
            }
            
            return shippingResult;
        }

        private string UPSRequest(string url, string requestText)
        {   // try request upto 3 times 
            string result = "";
            ASCIIEncoding encodedData = new ASCIIEncoding();
            byte[] byteArray = encodedData.GetBytes(requestText);


            int call_tries = 0;
            int call_max = 3;
            bool call_succeeded = false;

            while (call_tries < call_max && call_succeeded == false)
            {  // try three times before giving up
                call_tries++;
                try
                {
                    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                    wr.Method = "POST";
                    wr.KeepAlive = false;
                    wr.UserAgent = "Benz";
                    wr.ContentType = "application/x-www-form-urlencoded";
                    wr.ContentLength = byteArray.Length;

                    // send xml data
                    Stream SendStream = wr.GetRequestStream();
                    SendStream.Write(byteArray, 0, byteArray.Length);
                    SendStream.Close();

                    // get da response
                    HttpWebResponse WebResp = (HttpWebResponse)wr.GetResponse();
                    using (StreamReader sr = new StreamReader(WebResp.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    WebResp.Close();

                    call_succeeded = true;
                }
                catch (Exception e)
                {
                    System.Threading.Thread.Sleep(200);
                }
            }

            return result;
        }

        private string GetTrackingInfoUPSInString(string trackingNumber)
        {
            string apiUrl = "https://www.ups.com/ups.app/xml/Track"; // "https://wwwcie.ups.com/ups.app/xml/Track";

            string xml1 = "<?xml version=\"1.0\"?>" +
            "<AccessRequest xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
            @"	<Password>%PASSWORD%</Password>
	            <UserId>%USERID%</UserId>
            <AccessLicenseNumber>%ACCESSLICENSENUMBER%</AccessLicenseNumber>
            </AccessRequest>";



            string xml2 = @"<?xml version='1.0'?>
            <TrackRequest>
	            <Request>
		            <TransactionReference>
			
		            </TransactionReference>
		            <RequestAction>Track</RequestAction>
		            <RequestOption>0</RequestOption>
	            </Request>
	            <TrackingNumber>%TN%</TrackingNumber>
            </TrackRequest>";

            //string raw_response = UPSRequest(
            //    apiUrl, 
            //    xml1.Replace("%PASSWORD%", ConnectionString.UPS_PASSWORD).Replace("%USERID%",ConnectionString.UPS_USER_ID).Replace("%ACCESSLICENSENUMBER%",ConnectionString.UPS_ACCESS_LICENSE_NO)
            //    + xml2.Replace("%TN%", trackingNumber));
            string raw_response = UPSRequest(
                apiUrl,
                xml1.Replace("%ACCESSLICENSENUMBER%", ConnectionString.UPS_ACCESS_LICENSE_NO)
                + xml2.Replace("%TN%", trackingNumber));

            return raw_response;
        }

        private ShippingResult UPSTrackingResultWrap(UPSTrackingResult.TrackResponse resultingMessage)
        {
            ShippingResult shippingResult = new ShippingResult();

            UPSTrackingResult.TrackResponseResponse response = (UPSTrackingResult.TrackResponseResponse)resultingMessage.Items[0];
            if (response.ResponseStatusCode == "1")
            {
                UPSTrackingResult.TrackResponseShipment shipment = (UPSTrackingResult.TrackResponseShipment)resultingMessage.Items[1];
                shippingResult.ServiceType = shipment.Service[0].Description;
                shippingResult.StatusCode = shipment.Package[0].Activity[0].Status[0].StatusType[0].Code;
                shippingResult.Status = shipment.Package[0].Activity[0].Status[0].StatusType[0].Description;

                if (!string.IsNullOrEmpty(shippingResult.StatusCode))
                    if (shippingResult.StatusCode == "D")
                    {
                        shippingResult.Delivered = true;
                        shippingResult.StatusSummary = shipment.Package[0].Activity[0].ActivityLocation[0].Description;
                        shippingResult.DeliveredDateTime = shipment.Package[0].Activity[0].Date + " " + shipment.Package[0].Activity[0].Time;
                        shippingResult.SignatureName = string.IsNullOrEmpty(shipment.Package[0].Activity[0].ActivityLocation[0].SignedForByName) ? "" : shipment.Package[0].Activity[0].ActivityLocation[0].SignedForByName;
                    }


                if (!string.IsNullOrEmpty(shippingResult.StatusCode))
                    if (shippingResult.StatusCode != "D")
                    {
                        shippingResult.PickupDate = shipment.PickupDate;
                        shippingResult.ScheduledDeliveryDate = shipment.ScheduledDeliveryDate;

                        if (shipment.Package[0].Message != null)
                            shippingResult.Message = shipment.Package[0].Message[0].Description;
                    }
            }
            else
            {
                shippingResult.StatusCode = "Error";
                shippingResult.Status = response.Error.ErrorDescription;
                shippingResult.Message = response.Error.ErrorDescription;
            }

            return shippingResult;
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

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UPSTracking() {
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
