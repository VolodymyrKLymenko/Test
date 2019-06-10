using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4
{
    class Program
    {
        static void Main(string[] args)
        {

            var txi = new Population();
            var cars = new List<Car> {
                new Car{ EntetyId = 0, StartPoint = 0, Capacity = 4},
                new Car{ EntetyId = 1, StartPoint = 1, Capacity = 4}
            };

            var passangers = new List<Passanger> {
                new Passanger{
                    StartPoint = 2,
                    EndPoint = 3,
                    Count = 3,
                },
                new Passanger{
                    StartPoint = 4,
                    EndPoint = 5,
                    Count = 1
                },
                //new Passanger{
                //    StartPoint = 5,
                //    EndPoint = 7,
                //    Count = 2
                //}
            };

            var map = new double[,] {
                { 4,2,3,66,5,66 },
                { 6,2,62,67,6,123 },
                { 15,21,36,67,12,51 },
                {12,64,23,12,66,5 },
                {1,5,123,6, 61, 12 },
                {1,5,123,6, 61, 51 }
            };


            txi.Init(cars, passangers, map);
            var resultMatrix = txi.GetTheBestProfit();
            var pointsCount = cars.Count + 2*passangers.Count;

            foreach(var car in resultMatrix)
            {
                foreach(var point in car)
                {
                    Console.Write($"{point} ");
                }
                Console.WriteLine();
            }

            foreach (var chr in txi.Chromosomes)
            {
                Console.WriteLine(chr);
                Console.WriteLine("----------------");
            }
        }
    }
}
