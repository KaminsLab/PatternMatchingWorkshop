namespace TrafficPricing.Services
{
    /// <summary>
    /// Calculates tolls and peak time pricing for traffic managing.
    /// </summary>
    public interface ITollCalculator
    {
        /// <summary>
        /// Calculates toll.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        /// <returns>Price for vehicle service.</returns>
        public decimal CalculateToll(object vehicle);
    }
}