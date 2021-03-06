﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace ShippingTrackingUtilities
{
    public enum CarrierName { USPS =0, UPS= 1,FedEx =2}

    public class TrackingUtilities
    {
        ITrackingFacility trackingFacility;
        
        private ShippingResult shippingResult;

        public ShippingResult ShippingResult { get { return shippingResult; } }
        public string ShippingResultInString { get { return ConvertTrackingResultIntoString(); } }

        // Entry Point.
        public void GetTrackingResult(string trackingNo)
        {
            shippingResult = new ShippingResult();

            string shippingResultInString = string.Empty;

            if (!string.IsNullOrEmpty(trackingNo))
            {
                CarrierName carrier = getCarrierName(trackingNo);

                CredentialValidation(carrier);

                switch (carrier)
                {
                    case CarrierName.UPS:
                        trackingFacility = new UPSTracking();
                        break;
                    case CarrierName.USPS:
                        trackingFacility = new USPSTracking();
                        break;
                    case CarrierName.FedEx:
                        trackingFacility = new FedExTracking();
                        break;
                    default:
                        trackingFacility = new USPSTracking();
                        break;
                }

                shippingResult = trackingFacility.GetTrackingResult(trackingNo);
            }
        }

        private CarrierName getCarrierName(string trackingNo)
        {
            CarrierName carrierName = CarrierName.USPS;

            if (IsUPSTracking(trackingNo))
                carrierName = CarrierName.UPS;
            else if (IsUSPSTracking(trackingNo))
                carrierName = CarrierName.USPS;
            else
                carrierName = CarrierName.FedEx;

            return carrierName;
        }

        private bool IsUPSTracking(string trackingNo)
        {
            return trackingNo.Trim().ToUpper().StartsWith("1Z");
        }

        private bool IsUSPSTracking(string trackingNo)
        {
            return
                (
                (trackingNo.Trim().Length == 22 && trackingNo.Trim().StartsWith("9")) ||
                  (trackingNo.Trim().Length == 13 && trackingNo.Trim().EndsWith("US"))
                );
        }

        private void CredentialValidation(CarrierName carrier)
        {
            if (carrier == CarrierName.FedEx)
            {
                if (!HasFedExCredentialSetup())
                    throw new Exception("Please setup fedex credential first, before tracking fedex package.");
            }
            else if (carrier == CarrierName.USPS)
            {
                if (!HasUSPSCredentialSetup())
                    throw new Exception("Please setup USPS credential first, before tracking USPS package.");
            }
            else
            {
                if (!HasUPSCredentialSetup())
                    throw new Exception("Please setup UPS credential first, before tracking UPS package.");
            }
        }

        private bool HasFedExCredentialSetup()
        {
            return !string.IsNullOrEmpty(ConnectionString.FEDEX_USER_KEY)
                && !string.IsNullOrEmpty(ConnectionString.FEDEX_USER_PASSWORD);
        }

        private bool HasUSPSCredentialSetup()
        {
            return !string.IsNullOrEmpty(ConnectionString.USPS_USERID);
        }

        private bool HasUPSCredentialSetup()
        {
            return !string.IsNullOrEmpty(ConnectionString.UPS_ACCESS_LICENSE_NO);
        }

        //public string GetTrackingResultInString(string trackingNo)
        //{
        //    shippingResult = GetTrackingResult(trackingNo);

        //    return ConvertTrackingResultIntoString();

        //    //string result = "Delivered: " + shippingResult.Delivered;
        //    //result += "\n\nService Type: " + shippingResult.ServiceType;
        //    //result += "\nStatusCode: " + shippingResult.StatusCode + " " + "Status: " + shippingResult.Status;
        //    //result += "\nSummary: " + shippingResult.StatusSummary;

        //    //if (shippingResult.Delivered)
        //    //    result += "\nDelivered On: " + shippingResult.DeliveredDateTime;
        //    //else
        //    //{
        //    //    if (!string.IsNullOrEmpty(shippingResult.Message))
        //    //        result += "\nMessage: " + shippingResult.Message;
        //    //    if (!string.IsNullOrEmpty(shippingResult.ScheduledDeliveryDate))
        //    //        result += "\nScheduled Delivery Date: " + shippingResult.ScheduledDeliveryDate;
        //    //}

        //    //if (ConnectionString.ToShowDetails)
        //    //{
        //    //    if (shippingResult.TrackingDetails.Count > 0)
        //    //    {
        //    //        result += "\n\nTracking Details: ";

        //    //        foreach (var detail in shippingResult.TrackingDetails)
        //    //        {
        //    //            result += "\nEventDateTime: " + detail.EventDateTime;
        //    //            result += " Event: " + detail.Event;
        //    //            result += "\nEvent Address: " + detail.EventAddress;
        //    //        }
        //    //    }
        //    //}
 
        //    //return result;
        //}

        private string ConvertTrackingResultIntoString()
        {
            string result = "";

            if (shippingResult != null)
            {
                result = "Delivered: " + shippingResult.Delivered;
                result += "\n\nService Type: " + shippingResult.ServiceType;
                result += "\nStatusCode: " + shippingResult.StatusCode + " " + "Status: " + shippingResult.Status;
                result += "\nSummary: " + shippingResult.StatusSummary;

                if (shippingResult.Delivered)
                    result += "\nDelivered On: " + shippingResult.DeliveredDateTime;
                else
                {
                    if (!string.IsNullOrEmpty(shippingResult.Message))
                        result += "\nMessage: " + shippingResult.Message;
                    if (!string.IsNullOrEmpty(shippingResult.ScheduledDeliveryDate))
                        result += "\nScheduled Delivery Date: " + shippingResult.ScheduledDeliveryDate;
                }

                if (ConnectionString.ToShowDetails)
                {
                    if (shippingResult.TrackingDetails.Count > 0)
                    {
                        result += "\n\nTracking Details: ";

                        foreach (var detail in shippingResult.TrackingDetails)
                        {
                            result += "\nEventDateTime: " + detail.EventDateTime;
                            result += " Event: " + detail.Event;
                            result += "\nEvent Address: " + detail.EventAddress;
                        }
                    }
                }
            }
            else
            {
                result = "No result found.";
            }
           

            return result;
        }
    }
}
