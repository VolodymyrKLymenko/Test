using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map.Models
{
    public struct Point
    {
        public Point(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; private set; }
        public double Lng { get; private set; }
    }
}