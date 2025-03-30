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
        private const string fieldSeperator = "\t";
        private const string lineSeperator = "\r\n";
        private const double incorrectAngle = 4;
        private const double incorecctDistance = -1;
        private const double incorecctForce = -1;
        private const double incorecctHeight = -1;
        private const double incorecctTime = -1;
        private const double gravitationalConstant = 6.6743e-11;

        private readonly IOrbitItemsRepository orbitItemsRepository;
        private readonly IWriter writer;

        public static string FieldSepertor { get => fieldSeperator; }
        public static string LineSeperator { get => lineSeperator; }

        public TideCalculator(IOrbitItemsRepository orbitItemsRepository, IWriter writer)
        {
            if(orbitItemsRepository == null || writer == null)
            {
                if (orbitItemsRepository == null && writer == null)
                {
                    throw new ArgumentNullException(nameof(orbitItemsRepository) + " & " + nameof(writer));
                }
                else if (orbitItemsRepository == null)
                {
                    throw new ArgumentNullException(nameof(orbitItemsRepository));
                }
                else
                {
                    throw new ArgumentNullException(nameof(writer));
                }
            }
            this.orbitItemsRepository = orbitItemsRepository;
            this.writer = writer;
        }

        public double AngleTo(OrbitItem centralItem, OrbitItem itemAtZeroDegrees, OrbitItem measureItem, int time)
        {
            int? centralItemId = orbitItemsRepository.GetIdOf(centralItem);
            int? atZeroDegreesId = orbitItemsRepository.GetIdOf(itemAtZeroDegrees);
            int? measureItemId = orbitItemsRepository.GetIdOf(measureItem);

            if (centralItemId == null || atZeroDegreesId == null || measureItemId == null || centralItemId == atZeroDegreesId || centralItemId == measureItemId || atZeroDegreesId == measureItemId)
            {
                return incorrectAngle;
            }

            List<OrbitItem> items = GatherItems([(int)centralItemId, (int)atZeroDegreesId, (int)measureItemId]);

            if(items == null || items.Count == 0) { return incorrectAngle; }

            Dictionary<int, (double, double)> coordiantes = GetCoordinates(items, time);

            return GetAngle(coordiantes, (int)centralItemId, (int)atZeroDegreesId, (int)measureItemId);
        }

        public (double, double) DistanceAndAngleBetween(OrbitItem centralItem, OrbitItem measuringItem, OrbitItem itemAtZeroDegrees, int time)
        {
            int? centralItemId = orbitItemsRepository.GetIdOf(centralItem);
            int? atZeroDegreesId = orbitItemsRepository.GetIdOf(itemAtZeroDegrees);
            int? measureItemId = orbitItemsRepository.GetIdOf(measuringItem);

            if (centralItemId == null || atZeroDegreesId == null || measureItemId == null || centralItemId == atZeroDegreesId || centralItemId == measureItemId || atZeroDegreesId == measureItemId)
            {
                return (incorrectAngle, incorecctDistance);
            }

            List<OrbitItem> items = GatherItems([(int)centralItemId, (int)atZeroDegreesId, (int)measureItemId]);

            if (items == null || items.Count == 0) { return (incorrectAngle, incorecctDistance); }

            Dictionary<int, (double, double)> coordiantes = GetCoordinates(items, time);

            double angle = GetAngle(coordiantes, (int)centralItemId, (int)atZeroDegreesId, (int)measureItemId);
            double distance = GetDistance(coordiantes, (int)(centralItemId), (int)measureItemId);

            if (angle == incorrectAngle || distance == incorecctDistance)
            {
                return (incorrectAngle, incorecctDistance);
            }

            return (angle,  distance);


            throw new NotImplementedException();
        }

        public double DistanceBetween(OrbitItem ItemOne, OrbitItem ItemTwo, int time)
        {
            int? itemOneId = orbitItemsRepository.GetIdOf(ItemOne);
            int? itemTwoId = orbitItemsRepository.GetIdOf(ItemTwo);

            if (itemOneId == null || itemTwoId == null || itemOneId == itemTwoId)
            {
                return incorecctDistance;
            }

            List<OrbitItem> items = GatherItems([(int)itemOneId, (int)itemTwoId]);

            if (items == null || items.Count == 0) { return incorecctDistance; }

            Dictionary<int, (double, double)> coordiantes = GetCoordinates(items, time);

            double distance = GetDistance(coordiantes, (int)(itemOneId), (int)itemTwoId);

            if (distance == incorecctDistance)
            {
                return incorecctDistance;
            }

            return distance;
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
            int? experiancerId = orbitItemsRepository.GetIdOf(experiancer);
            int? excerterId = orbitItemsRepository.GetIdOf(excerter);

            if (experiancerId == null || excerterId == null || experiancerId == excerterId)
            {
                return incorecctForce;
            }

            List<OrbitItem> items = GatherItems([(int)experiancerId, (int)excerterId]);

            if (items == null || items.Count == 0) { return incorecctForce; }

            Dictionary<int, (double, double)> coordiantes = GetCoordinates(items, time);

            double distance = GetDistance(coordiantes, (int)(experiancerId), (int)excerterId);

            if (distance == incorecctDistance)
            {
                return incorecctForce;
            }

            return GetTidalForce(experiancer, excerter, distance);
        }

        public double TidalHeightBetweenTwoBodies(OrbitItem experiancer, OrbitItem excerter, int time)
        {
            int? experiancerId = orbitItemsRepository.GetIdOf(experiancer);
            int? excerterId = orbitItemsRepository.GetIdOf(excerter);

            if (experiancerId == null || excerterId == null || experiancerId == excerterId)
            {
                return incorecctHeight;
            }

            List<OrbitItem> items = GatherItems([(int)experiancerId, (int)excerterId]);

            if (items == null || items.Count == 0) { return incorecctHeight; }

            Dictionary<int, (double, double)> coordiantes = GetCoordinates(items, time);

            double distance = GetDistance(coordiantes, (int)(experiancerId), (int)excerterId);

            if (distance == incorecctDistance)
            {
                return incorecctHeight;
            }

            return GetTidalRange(experiancer, excerter, distance);
        }

        public int TimeTillRestart()
        {
            throw new NotImplementedException();
        }

        public (double, double, double, double) TotalTidalForceAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
        {
            throw new NotImplementedException();
        }

        public (double, double, double, double) TotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
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

        public bool WriteTotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        private List<OrbitItem> GatherItems(IEnumerable<int> ids)
        {
            List<OrbitItem> orbitItems = new();

            //add the orbititems of the given ids to the list
            foreach (int id in ids)
            {
                orbitItems.Add(orbitItemsRepository.Get(id));
            }

            for (int i = 0; i<orbitItems.Count; i++)
            {
                if(orbitItems[i] == null)
                {
                    return null;
                }

                if (orbitItems[i].OrbitingId != 0)
                {
                    bool orbitingIdAlreadyContains = false;
                    for (int j = 0; j<orbitItems.Count; j++)
                    {
                        if(i!=j && orbitItems[j].Id == orbitItems[i].OrbitingId)
                        {
                            orbitingIdAlreadyContains = true;
                            break;
                        }
                    }

                    if (!orbitingIdAlreadyContains)
                    {
                        orbitItems.Add(orbitItemsRepository.Get(orbitItems[i].OrbitingId));
                    }
                }
            }

            return orbitItems;
        }

        private static Dictionary<int, (double, double)> GetCoordinates(List<OrbitItem> items, int time)
        {
            Dictionary<int, (double, double)> coordinates = new();

            bool everyItemCovered = false;
            do
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (!coordinates.ContainsKey(items[i].Id))
                    {
                        if (items[i].OrbitingId == 0)
                        {
                            coordinates.Add(items[i].Id, (0, 0));
                        }
                        else if (coordinates.TryGetValue(items[i].OrbitingId, out (double, double) orbitedCoordiates))
                        {
                            double x = orbitedCoordiates.Item1 + items[i].OrbitingDistance * Math.Cos(Math.PI * 2 * time / items[i].OrbitPeriod);
                            double y = orbitedCoordiates.Item2 + items[i].OrbitingDistance * Math.Sin(Math.PI * 2 * time / items[i].OrbitPeriod);
                            coordinates.Add(items[i].Id, (x, y));
                        } 
                    }
                }

                everyItemCovered = true;
                for (int i = 0; i < items.Count; i++)
                {
                    if (!coordinates.ContainsKey(items[i].Id))
                    {
                        everyItemCovered = false;
                        break;
                    }
                }
            }
            while (!everyItemCovered);

            return coordinates;
        }

        private static double GetAngle(Dictionary<int, (double, double)> coordinates, int centralId, int atZeroId, int measureId)
        {
            (double, double) vectorOne = (coordinates[atZeroId].Item1 - coordinates[centralId].Item1, coordinates[atZeroId].Item2 - coordinates[centralId].Item2);
            (double, double) vectorTwo = (coordinates[measureId].Item1 - coordinates[centralId].Item1, coordinates[measureId].Item2 - coordinates[centralId].Item2);
            return GetAngle(vectorOne, vectorTwo);
        }

        private static double GetAngle(Dictionary<int, (double, double)> coordinates, int centralId, int atZeroId, (double, double) vectorTwo)
        {
            (double, double) vectorOne = (coordinates[atZeroId].Item1 - coordinates[centralId].Item1, coordinates[atZeroId].Item2 - coordinates[centralId].Item2);

            return GetAngle(vectorOne, vectorTwo);
        }

        private static double GetAngle((double, double) vectorOne, (double, double) vectorTwo)
        {
            double vectorOneTimesVectorTwo = vectorOne.Item1 * vectorTwo.Item1 + vectorOne.Item2 * vectorTwo.Item2;
            double absoluteVectorOne = Math.Pow(Math.Pow(vectorOne.Item1, 2) + Math.Pow(vectorOne.Item2, 2), 0.5);
            double absoluteVectorTwo = Math.Pow(Math.Pow(vectorTwo.Item1, 2) + Math.Pow(vectorTwo.Item2, 2), 0.5);
            double angle = Math.Acos(vectorOneTimesVectorTwo / (absoluteVectorOne * absoluteVectorTwo));
            double crossProduct = vectorOne.Item1 * vectorTwo.Item2 - vectorOne.Item2 * vectorTwo.Item1;

            if (crossProduct >= 0)
            {
                return angle;
            }
            else
            {
                return -angle;
            }
        }

        private static double GetDistance(Dictionary<int, (double, double)> coordiantes, int centralItemId, int measureItemId)
        {
            return Math.Pow(Math.Pow(coordiantes[centralItemId].Item1 - coordiantes[measureItemId].Item1, 2) + Math.Pow(coordiantes[centralItemId].Item2 - coordiantes[measureItemId].Item2, 2), 0.5);
        }

        private static double GetTidalForce(OrbitItem experiancer, OrbitItem excerting, double distance)
        {
            return 2 * gravitationalConstant * excerting.Mass * experiancer.Radius / Math.Pow(distance, 3);
        }

        private static double GetTidalRange(OrbitItem experiancer, OrbitItem excerting, double distance)
        {
            return Math.Pow(experiancer.Radius, 4) / Math.Pow(distance, 3) * excerting.Mass / experiancer.Mass;
        }
    }
}
