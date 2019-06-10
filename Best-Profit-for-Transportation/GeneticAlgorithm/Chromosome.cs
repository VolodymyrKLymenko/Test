using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Chromosome : IComparable<Chromosome>
    {
        private static Random rand = new Random(Environment.TickCount);

        private int[] PassangersMove;

        public Chromosome(List<Car> cars, List<Passanger> passangers)
        {
            InitializePassangerMove(passangers);
            Gene = GenerateRandom(cars, passangers);
        }

        public int CompareTo(Chromosome other)
        {
            return 0;
        }

        public static int CalculateFitness(string gene)
        {
            int fitness = 0;

            return fitness;
        }
        
        public List<Car> GenerateRandom(List<Car> cars, List<Passanger> passangers)
        {
            var chromosomes = new List<Car>();
            //Shallow copies
            chromosomes.AddRange(cars.Select( c => new Car(c)));

            foreach (var passanger in passangers)
            {
                var carNumber = rand.Next(0,chromosomes.Count - 1);
                var selectedCar = chromosomes.First(c => c.EntetyId == carNumber);

                selectedCar.Route.Add(passanger.StartPoint);
                selectedCar.Route.Add(passanger.EndPoint);
            }

            foreach (var car in chromosomes)
            {
                if (car.Route.Count > 0)
                {
                    Evolve(car);
                }
            }

            return chromosomes;
        }

        public static double EvaluateRoute(int[] points)
        {
            return 0;
        }

        public static double EvaluationFunc()
        {
            return 0;
        }

        private void Evolve(Car car)
        {
            var newRoute = new List<int>();
            var belowZeroCount = car.Route.Where(el => PassangersMove[el] > 0);
            var firstPoint = belowZeroCount.ElementAt(rand.Next(belowZeroCount.Count()));
            var passangerCount = PassangersMove[firstPoint];

            newRoute.Add(firstPoint);
            car.Route.Remove(firstPoint);

            while (car.Route.Count > 0)
            {
                var randPoint = car.Route[rand.Next(car.Route.Count)];
                var newPassangerCount = passangerCount + PassangersMove[randPoint];

                if (newPassangerCount >= 0 && newPassangerCount < car.Capacity)
                {
                    passangerCount = newPassangerCount;
                    newRoute.Add(randPoint);
                    car.Route.Remove(randPoint);
                }
            }

            car.Route = newRoute;
        }
    
        private void InitializePassangerMove(List<Passanger> passangers)
        {
            PassangersMove = new int[100];
            foreach (var passanger in passangers)
            {
                PassangersMove[passanger.StartPoint] = passanger.Count;
                PassangersMove[passanger.EndPoint] = -passanger.Count;
            }
        }

        public List<Car> Gene { get; private set; }

        public override string ToString()
        {
            var str = "";
            foreach (var element in Gene)
            {
                foreach (var r in element.Route)
                {
                    str += r;
                }
                str += '\n';
            }
            return str;
        }
    }
}
