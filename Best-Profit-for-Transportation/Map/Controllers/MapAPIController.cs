using GeneticAlgorithm;
using Map.Helpers;
using Map.Models;
using Map.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Map.Controllers
{
    public class MapAPIController : ApiController
    {
        private CarRepository carRepository;
        private PassangerRepository passangerRepository;

        public MapAPIController() {

            carRepository = new CarRepository();
            passangerRepository = new PassangerRepository();
        }

        [HttpPost]
        public int[][] CalculateBestRoute(double[][] map)
        {
            MapModel.SetNewPoint(map);
          
            var routeGeneration = new Population();

            routeGeneration.Init(carRepository.GetCars(), 
                                 passangerRepository.GetPassangers(MapModel.PassangerCount + 1), 
                                 MapModel.MapDistance);

            MapModel.PassangerCount++;
            return RouteMatrixConverter.ConvertToMatrix<int>(routeGeneration.GetTheBestProfit());
        }
    }
}
