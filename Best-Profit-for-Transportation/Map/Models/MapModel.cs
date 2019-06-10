using Map.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map.Models
{
    public static class MapModel
    {
        static MapModel()
        {
            var carRepository = new CarRepository();
            var carCount = carRepository.GetCars().Count;
            MapPoints = carRepository.GetCars().Select(e => new Point(e.Lat, e.Lng)).ToList();
            MapDistance = new double[carCount][];

            for (int i = 0; i < carCount; ++i)
            {
                MapDistance[i] = new double[carCount];
            }

            PassangerCount = 0;
        }

        public static double[][] MapDistance;

        public static List<Point> MapPoints;

        public static int PassangerCount { get; set; }

        public static void SetNewPoint(double[][] newPointDistance)
        {
            var oldMatrixCount = MapDistance.Count();

            var pointMediator = 2;

            var newMapDistance = new double[oldMatrixCount + pointMediator][];

            for (int i = 0; i < newMapDistance.Count(); ++i)
            {
                newMapDistance[i] = new double[newMapDistance.Count()];
            }
            
            for (int i = 0; i < oldMatrixCount; ++i)
            {
                for (int j = 0; j < oldMatrixCount; ++j)
                {
                    newMapDistance[i][j] = MapDistance[i][j];
                }
            }

            for (int i = 0; i < pointMediator; ++i)
            {
                for (int j = 0; j < newPointDistance[i].Count(); ++j)
                {
                    newMapDistance[oldMatrixCount + i][j] = newPointDistance[i][j];
                }
            }

            for (int i = 0; i < pointMediator; i++)
            {
                for (int j = 0; j < newPointDistance[i].Count(); ++j)
                {
                    newMapDistance[j][i + oldMatrixCount] = newPointDistance[i + pointMediator][j];
                }
            }

            MapDistance = newMapDistance;
        }
    }
}