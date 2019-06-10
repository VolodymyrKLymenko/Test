using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Map.Repositories
{
    public class PassangerRepository
    {
        private const int CAR_COUNT = 2;

        public List<Passanger> GetPassangers(int count)
        {
            var passangerList = new List<Passanger>();

            for (int i = CAR_COUNT; i < 2*count + CAR_COUNT; ++i)
            {
                passangerList.Add(new Passanger() { EntetyId = i, StartPoint = i, EndPoint = ++i, Count = 2});
            }

            return passangerList;
        }
    }
}