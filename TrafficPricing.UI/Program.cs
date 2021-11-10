using System;
using Data.CommercialRegistration;
using Data.LiveryRegistration;
using TrafficPricing.Services;

namespace TrafficPricing.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tollCalc = new TollCalculator();
            var car = new Car();
            var taxi = new Taxi();
            var bus = new Bus();
            var truck = new DeliveryTruck();
            
            Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
            Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");
            
            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            
            try
            {
                tollCalc.CalculateToll(null!);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
            
            ITollCalculator tollCalcForPassenger = new TollPassengersCalculator();
            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emptyTaxi = new Taxi();
            var singleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };
            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };
            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truckBase = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };
            Console.WriteLine($"The toll for a solo driver is {tollCalcForPassenger.CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {tollCalcForPassenger.CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {tollCalcForPassenger.CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {tollCalcForPassenger.CalculateToll(fullVan)}");
            Console.WriteLine($"The toll for an empty taxi is {tollCalcForPassenger.CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {tollCalcForPassenger.CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {tollCalcForPassenger.CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {tollCalcForPassenger.CalculateToll(fullVanPool)}");
            Console.WriteLine($"The toll for a low-occupant bus is {tollCalcForPassenger.CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {tollCalcForPassenger.CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {tollCalcForPassenger.CalculateToll(fullBus)}");
            Console.WriteLine($"The toll for a truck is {tollCalcForPassenger.CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {tollCalcForPassenger.CalculateToll(truckBase)}");
            Console.WriteLine($"The toll for a truck is {tollCalcForPassenger.CalculateToll(lightTruck)}");
            try
            {
                tollCalcForPassenger.CalculateToll("this will fail");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalcForPassenger.CalculateToll(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
        }
    }
}