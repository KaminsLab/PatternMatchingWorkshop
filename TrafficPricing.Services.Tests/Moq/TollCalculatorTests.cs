using Data.CommercialRegistration;
using Data.LiveryRegistration;
using Moq;
using NUnit.Framework;

namespace TrafficPricing.Services.Tests.Moq
{
    public class TollCalculatorTests
    {
        private Mock<ITollCalculator> mock = new Mock<ITollCalculator>();
        
        [TestCase(1.2)]
        [TestCase(2.4)]
        [TestCase(5)]
        public void CalculateToll_ObjectIsMathToVehicle_ReturnPrice(decimal price)
        {
            var car = new Car();
            
            mock.Setup(c => c.CalculateToll(It.IsAny<Car>())).Returns(price);

            var stub = mock.Object;

            Assert.AreEqual(stub.CalculateToll(car), price);
        }
    }
}