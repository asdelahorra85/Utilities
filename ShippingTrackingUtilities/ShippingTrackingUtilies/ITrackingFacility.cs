using System.Collections.Generic;

namespace ShippingTrackingUtilities
{
    public interface ITrackingFacility
    {
        ShippingResult GetTrackingResult(string trackingNumber);

        List<ShippingResult> GetTrackingResult(List<string> trackingNumbers);
    }
}
