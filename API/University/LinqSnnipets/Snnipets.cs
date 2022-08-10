using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LinqSnnipets
{
    public class Snnipets
    {
        public static void BasicLinQ()
        {
            string[] cars = { "Mazda", "VW California", "VW Golf", "Audi A3", "Audi A4", "Fiat Punto", "Seat Ibiza", "Seat Leon" };

            // 1. SELECT * FROM cars
            var carList = from car in cars select car;
            foreach (var car in cars) {
                Console.WriteLine(car);
            }
        }
    }
}