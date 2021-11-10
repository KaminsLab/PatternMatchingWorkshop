using System;
using Data.CommercialRegistration;
using Data.LiveryRegistration;

namespace TrafficPricing.Services
{
    /// <inheritdoc cref="ITollCalculator"/>
    public class TollCalculator : ITollCalculator
    {
        /// <summary>
        /// Calculates toll according to vehicle's type.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        /// <returns>Price for vehicle service.</returns>
        /// <exception cref="ArgumentException">Throws, when the type of vehicle is unknown.</exception>
        /// <exception cref="ArgumentNullException">Throws, when the vehicle is null.</exception>
        public virtual decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c => 2.00m,
                Taxi t => 3.50m,
                Bus b => 5.00m,
                DeliveryTruck t => 10.00m,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}