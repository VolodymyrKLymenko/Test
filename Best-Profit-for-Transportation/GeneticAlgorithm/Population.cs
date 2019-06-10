using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm
{
    public class Population
    {
        public List<Chromosome> Chromosomes { get; set; }

        public const int CHROMOSOME_COUNT = 10;

        public Population()
        {
            Chromosomes = new List<Chromosome>(CHROMOSOME_COUNT);
        }

        public void Evolve()
        {

        }

        public void Init(List<Car> cars, List<Passanger> passangers, double[][] map)
        {
            for (int i = 0; i < CHROMOSOME_COUNT; ++i)
            {
                Chromosomes.Add(new Chromosome(cars, passangers));
            }

            Cars = cars;
            Passangers = passangers;
            Map = map;
        }

        public List<List<int>> GetTheBestProfit()
        {
            double bestProfit = 0;
            Chromosome bestSolution = null;
            foreach (var chromosome in Chromosomes)
            {
                var currentProfit = CalculateRouteProfit(chromosome);
                if (currentProfit > bestProfit)
                {
                    bestProfit = currentProfit;
                    bestSolution = chromosome;
                }
            }

            return ConvertChromosome(bestSolution.Gene);
        }

        public double[][] Map { get; set; }

        public List<Car> Cars { get; set; }

        public List<Passanger> Passangers { get; set; }

        private List<Chromosome> Selection()
        {
            return null;
        }

        private List<List<int>> ConvertChromosome(List<Car> gens)
        {
            return gens.Select(el => {
                var mas = new List<int>() { el.StartPoint };
                mas.AddRange(el.Route);
                return mas;
            }).ToList();
        }
        
        private double CalculateRouteProfit(Chromosome chromosome)
        {
            double sum = 0;
            foreach (var car in chromosome.Gene)
            {
                if (car.Route.Count > 0)
                {
                    sum += Map[car.EndPoint][car.Route[0]];
                    for (int i = 1; i < car.Route.Count; ++i)
                    {
                        sum += Map[car.Route[i - 1]][car.Route[i]] * car.Price;
                    }
                }
            }

            return sum;
        }
    }
}
