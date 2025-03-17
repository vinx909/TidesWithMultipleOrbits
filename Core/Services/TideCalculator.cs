using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TideCalculator : ITideCalculator
    {
        private readonly IOrbitItemsRepository orbitItemsRepository;
        private readonly IWriter writer;

        public TideCalculator(IOrbitItemsRepository orbitItemsRepository, IWriter writer)
        {
            this.orbitItemsRepository = orbitItemsRepository;
            this.writer = writer;
        }

        public double AngleTo(OrbitItem itemCentral, OrbitItem itemAtZeroDegrees, OrbitItem itemMeasure, int time)
        {
            throw new NotImplementedException();
        }

        public (double, double) DistanceAndAngleBetween(OrbitItem centralItem, OrbitItem measuringItem, OrbitItem itemAtZeroDegrees, int time)
        {
            throw new NotImplementedException();
        }

        public double DistanceBetween(OrbitItem ItemOne, OrbitItem ItemTwo, int time)
        {
            throw new NotImplementedException();
        }

        public bool ProvideRangeToWorkWith(IEnumerable<OrbitItem> items)
        {
            throw new NotImplementedException();
        }

        public bool SetWritePath(string path)
        {
            throw new NotImplementedException();
        }

        public double TidalForceBetweenTwoBodies(OrbitItem experiancer, OrbitItem excerter, int time)
        {
            throw new NotImplementedException();
        }

        public double TidalHeightBetweenTwoBodies(OrbitItem experiancer, OrbitItem excerter, int time)
        {
            throw new NotImplementedException();
        }

        public int TimeTillRestart()
        {
            throw new NotImplementedException();
        }

        public (double, double) TotalTidalForceAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
        {
            throw new NotImplementedException();
        }

        public (double, double) TotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
        {
            throw new NotImplementedException();
        }

        public bool WriteAngleToFile(OrbitItem itemCentral, OrbitItem itemAtZeroDegrees, OrbitItem itemMeasure, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        public bool WriteDistanceAndAngleBetweenToFile(OrbitItem centralItem, OrbitItem measuringItem, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        public bool WriteDistanceBetweenToFile(OrbitItem ItemOne, OrbitItem ItemTwo, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        public bool WriteTotalTidalForceAndAngleToFile(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        public bool WriteTotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
        {
            throw new NotImplementedException();
        }

        public class NotInGivenRangeException : Exception;
    }
}
