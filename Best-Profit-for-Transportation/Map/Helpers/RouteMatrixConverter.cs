using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map.Helpers
{
    public static class RouteMatrixConverter
    {
        public static T[][] ConvertToMatrix<T>(List<List<T>> routes)
        {
            var rowsCount = routes.Count();
            var matrix = new T[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = new T[routes[i].Count];
                for (int j = 0; j < routes[i].Count; j++)
                {
                    matrix[i][j] = routes[i][j];
                }
            }

            return matrix;
        }
    }
}