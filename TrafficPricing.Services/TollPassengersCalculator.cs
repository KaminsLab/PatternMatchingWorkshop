﻿using System;
using Data.CommercialRegistration;
using Data.LiveryRegistration;

namespace TrafficPricing.Services
{
    /// <inheritdoc cref="TollCalculator"/>
    public class TollPassengersCalculator : TollCalculator
    {
        /// <summary>
        /// Calculates toll according to vehicle's type and count of passengers.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        /// <returns>Price for vehicle service.</returns>
        /// <exception cref="ArgumentException">Throws, when the type of vehicle is unknown.</exception>
        /// <exception cref="ArgumentNullException">Throws, when the vehicle is null.</exception>
        public override decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => 2.00m + 0.5m,
                    1 => 2.0m,
                    2 => 2.0m - 0.5m,
                    _ => 2.00m - 1.0m
                },
                Taxi t => t.Fares switch
                {
                    0 => 3.50m + 1.00m,
                    1 => 3.50m,
                    2 => 3.50m - 0.50m,
                    _ => 3.50m - 1.00m
                },
                Bus b when b.Riders / (double)b.Capacity < 0.50 => 5.00m + 2.00m,
                Bus b when b.Riders / (double)b.Capacity > 0.90 => 5.00m - 1.00m,
                Bus b => 5.00m,
                DeliveryTruck t when t.GrossWeightClass > 5000 => 10.00m + 5.00m,
                DeliveryTruck t when t.GrossWeightClass < 3000 => 10.00m - 2.00m,
                DeliveryTruck t => 10.00m,
                { }  => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}