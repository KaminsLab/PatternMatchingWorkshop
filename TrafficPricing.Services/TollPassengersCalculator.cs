using System;
using Data.CommercialRegistration;
using Data.LiveryRegistration;

namespace TrafficPricing.Services
{
    public class TollPassengersCalculator : TollCalculator
    {
        public override decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Taxi {Fares: 0} => 3.50m + 1.00m,
                Taxi {Fares: 1} => 3.50m,
                Taxi {Fares: 2} => 3.50m - 0.50m,
                Taxi => 3.50m - 1.00m,
                Bus b when b.Riders / (double)b.Capacity < 0.50 => 5.00m + 2.00m,
                Bus b when b.Riders / (double)b.Capacity > 0.90 => 5.00m - 1.00m,
                Bus => 5.00m,                
                DeliveryTruck t when t.GrossWeightClass > 5000 => 10.00m + 5.00m,
                DeliveryTruck t when t.GrossWeightClass < 3000 => 10.00m - 2.00m,
                DeliveryTruck => 10.00m,         
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}