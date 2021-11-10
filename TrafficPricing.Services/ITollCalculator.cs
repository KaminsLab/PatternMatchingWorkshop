namespace TrafficPricing.Services
{
    public interface ITollCalculator
    {
        public decimal CalculateToll(object vehicle);
    }
}