using System;

namespace TrafficPricing.Services
{
    /// <inheritdoc cref="TollPassengersCalculator"/>
    public class TollTimeCalculator : TollPassengersCalculator
    {
        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        /// <summary>
        /// Calculates toll according to vehicle's type, count of passengers and time of toll.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        /// <param name="timeOfToll">Time of toll.</param>
        /// <param name="inbound">Type of traffic - inbound or outbound.</param>
        /// <returns>Price for vehicle service.</returns>
        /// <exception cref="ArgumentException">Throws, when the type of vehicle is unknown.</exception>
        /// <exception cref="ArgumentNullException">Throws, when the vehicle is null.</exception>
        public decimal CalculateToll(object vehicle, DateTime timeOfToll, bool inbound)
            => this.CalculateToll(vehicle) * PeakTimePremiumFull(timeOfToll, inbound);

        private decimal PeakTimePremiumFull(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m,
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                (false, _, _) => 1.0m,
                _ => 1.0m
            };

        private static bool IsWeekDay(DateTime timeOfToll) =>
            timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true
            };
        
        private static TimeBand GetTimeBand(DateTime timeOfToll) =>
            timeOfToll.Hour switch
            {
                < 6 or > 19 => TimeBand.Overnight,
                < 10 => TimeBand.MorningRush,
                < 16 => TimeBand.Daytime,
                _ => TimeBand.EveningRush,
            };
    }
}