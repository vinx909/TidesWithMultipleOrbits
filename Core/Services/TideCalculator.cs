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

        private string path = string.Empty;

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
            //check if the values are good
            bool orbitingIdZeroFound = false;
            foreach (OrbitItem item in items)
            {
                //make sure every item eventually orbits an item that doesn't orbit
                if(!(item.OrbitingId == 0 || FindOrigin(item.OrbitingId, item.Id)))
                {
                    return false;
                }

                //make sure there's only one item that doesn't orbit
                else if(item.OrbitingId == 0)
                {
                    if (!orbitingIdZeroFound)
                    {
                        orbitingIdZeroFound = true;
                    }
                    else
                    {
                        return false;
                    }
                }

                //make sure there's no item with the same id or same value
                foreach(OrbitItem otherItem in items)
                {
                    if (item != otherItem)
                    {
                        if (item.Id == otherItem.Id)
                        {
                            return false;
                        }
                        else if (IsSameOrbitItem(item, otherItem))
                        {
                            return false;
                        }
                    }
                }
            }

            //see if there are old items, and if so delete them
            foreach (OrbitItem item in orbitItemsRepository.GetAll())
            {
                if(!orbitItemsRepository.Delete(item, true))
                {
                    return false;
                }
            }

            //add items
            return orbitItemsRepository.Add(items);

            bool FindOrigin(int id, int startId)
            {
                foreach (OrbitItem item in items)
                {
                    if (item.Id == id)
                    {
                        if (item.OrbitingId == 0)
                        {
                            return true;
                        }
                        else if (item.OrbitingId == startId)
                        {
                            return false;
                        }
                        else
                        {
                            return FindOrigin(item.OrbitingId, startId);
                        }
                    }
                }
                return false;
            }
        }

        public bool SetWritePath(string path)
        {
            if (!writer.IsWriting() && writer.CanWriteTo(path))
            {
                this.path = path;
                return true;
            }
            else
            {
                this.path = string.Empty;
                return false;
            }
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
            List<int> periods = [];
            List<double> Angles = [];
            int maximum = 1;

            IEnumerable<OrbitItem> items = orbitItemsRepository.GetAll();
            if(items == null || !items.Any())
            {
                return (int)incorecctTime;
            }

            foreach (OrbitItem item in items)
            {
                if (item.OrbitingId != 0)
                {
                    maximum *= item.OrbitPeriod;
                    periods.Add(item.OrbitPeriod);
                    Angles.Add(0);
                }
            }

            //check if it's always the same due to either only 1 orbiting item or all orbits being the same
            if(periods.Count < 2) 
            {
                return 0;
            }
            else
            {
                bool allTheSame = true;
                for (int i = 1; i < periods.Count; i++)
                {
                    if (periods[0] != periods[i])
                    {
                        allTheSame = false;
                        break;
                    }
                }
                if (allTheSame)
                {
                    return 0;
                }
            }

            for (int i = 1; i <= maximum; i++)
            {
                for (int j = 0; j < periods.Count; j++)
                {
                    Angles[j] = (1.0 * i / periods[j]) % 1;
                }

                bool allTheSameAngle = true;
                for(int j = 1; j < periods.Count; j++)
                {
                    if (Angles[0] != Angles[j])
                    {
                        allTheSameAngle = false;
                        break;
                    }
                }
                if (allTheSameAngle)
                {
                    return i;
                }
            }

            return (int)incorecctTime;
        }

        public (double, double, double, double) TotalTidalForceAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time)
        {
            if (!GetAll(experiancer, itemAtZeroDegrees, out List<OrbitItem> items, out OrbitItem trueExperiencer, out OrbitItem trueItemAtZeroDegrees)) { return returnIncorrect(); }

            Dictionary<int, (double, double)> coordinates = GetCoordinates(items, time);

            (double, double)[] forcesAndAngles = new (double, double)[coordinates.Count - 1];

            int index = 0;
            foreach (OrbitItem item in items)
            {
                if (item != trueExperiencer)
                {
                    forcesAndAngles[index] = (GetTidalForce(trueExperiencer, item, GetDistance(coordinates, trueExperiencer.Id, item.Id)), CorrectAngle(GetAngle(coordinates, trueExperiencer.Id, itemAtZeroDegrees.Id, item.Id)));
                    index++;
                }
            }

            return GetTotalAndAngle(forcesAndAngles);

            static (double, double, double, double) returnIncorrect()
            {
                return (incorecctForce, incorecctForce, incorecctForce, incorrectAngle);
            }
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

        public bool WriteTotalTidalHeightAndAngleToFile(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps)
        {
            throw new NotImplementedException();
        }

        private static bool IsSameOrbitItem(OrbitItem item, OrbitItem otherItem)
        {
            return item.Name.Equals(otherItem.Name) && item.Mass == otherItem.Mass && item.Radius == otherItem.Radius && item.OrbitingDistance == otherItem.OrbitingDistance && item.OrbitPeriod == otherItem.OrbitPeriod;
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
                            double x = orbitedCoordiates.Item1 + items[i].OrbitingDistance * Math.Cos(2.0 * time / items[i].OrbitPeriod * Math.PI);
                            double y = orbitedCoordiates.Item2 + items[i].OrbitingDistance * Math.Sin(2.0 * time / items[i].OrbitPeriod * Math.PI);
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

        private static double GetDistance(Dictionary<int, (double, double)> coordiantes, int itemOneId, int itemTwoId)
        {
            return Math.Pow(Math.Pow(coordiantes[itemOneId].Item1 - coordiantes[itemTwoId].Item1, 2) + Math.Pow(coordiantes[itemOneId].Item2 - coordiantes[itemTwoId].Item2, 2), 0.5);
        }

        private static double GetTidalForce(OrbitItem experiancer, OrbitItem excerting, double distance)
        {
            return 2 * gravitationalConstant * excerting.Mass * experiancer.Radius / Math.Pow(distance, 3);
        }

        private static double GetTidalRange(OrbitItem experiancer, OrbitItem excerting, double distance)
        {
            return Math.Pow(experiancer.Radius, 4) / Math.Pow(distance, 3) * excerting.Mass / experiancer.Mass;
        }

        private bool GetAll(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, out List<OrbitItem> items, out OrbitItem itemOne, out OrbitItem itemTwo)
        {
            itemOne = null;
            itemTwo = null;
            items = null;

            IEnumerable<OrbitItem> GetAllResults = orbitItemsRepository.GetAll();
            if (GetAllResults == null || !GetAllResults.Any()) { return false; }
            items = new(GetAllResults);

            foreach (OrbitItem item in items)
            {
                if (itemOne == null && IsSameOrbitItem(item, experiancer))
                {
                    itemOne = item;
                }
                if (itemTwo == null && IsSameOrbitItem(item, itemAtZeroDegrees))
                {
                    itemTwo = item;
                }
                if (itemOne != null && itemTwo != null)
                {
                    return itemOne != itemTwo; //the two items should not be the same in any of the cases where they are used.
                }
            }
            return false;
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

        private static double CorrectAngle(double angle)
        {
            if (angle > -0.5 * Math.PI && angle <= 0.5 * Math.PI)
            {
                return angle;
            }
            else if (angle > 0.5 * Math.PI && angle <= 1.5 * Math.PI)
            {
                return angle - Math.PI;
            }
            else if (angle <= 0.5 * Math.PI && angle > -1.5 * Math.PI)
            {
                return angle + Math.PI;
            }
            else
            {
                throw new Exception("the program is trying to work with an angle of "+angle+" or "+angle/Math.PI+ "π that it should not be able to generate and can't propperly handle");
            }
        }

        private static (double, double, double, double) GetTotalAndAngle((double, double)[] totalAndAngles)
        {
            const double neepTideTollerance = 0.00000000001;
            const double neepTideAngle = 0;

            double angle;
            if (totalAndAngles.Length == 0)
            {
                return (0, 0, 0, 0);
            }
            else if (totalAndAngles.Length == 1)
            {
                return (totalAndAngles[0].Item1, totalAndAngles[0].Item1 / 2, totalAndAngles[0].Item1 / 2, totalAndAngles[0].Item2);
            }
            else
            {
                //this builds on how you calculate R and ϕ whehn you know A, α, B, and β in A·cos(ωt+α)+B·cos(ωt+β)=R·cos(ωt+ϕ)
                double cosMultiplier = totalAndAngles[0].Item1;
                double angleAddition = totalAndAngles[0].Item2;
                double newcosMultiplier;

                for (int i = 1; i < totalAndAngles.Length; i++)
                {
                    //R = ((A·cos(α)+B·cos(β))2+(A·sin(α)+B·sin(β))2)1/2 
                    newcosMultiplier =
                        Math.Pow(
                            Math.Pow(cosMultiplier * Math.Cos(angleAddition) + totalAndAngles[i].Item1 * Math.Cos(totalAndAngles[i].Item2), 2) +
                            Math.Pow(cosMultiplier * Math.Sin(angleAddition) + totalAndAngles[i].Item1 * Math.Sin(totalAndAngles[i].Item2), 2), 0.5);
                    angleAddition = Math.Atan2(
                        cosMultiplier * Math.Sin(angleAddition) + totalAndAngles[i].Item1 * Math.Sin(totalAndAngles[i].Item2),
                        cosMultiplier * Math.Cos(angleAddition) + totalAndAngles[i].Item1 * Math.Cos(totalAndAngles[i].Item2));
                    cosMultiplier = newcosMultiplier;
                }

                angle = CorrectAngle(angleAddition);
            }

            double totalAtAnlge = 0;
            double totalPerpendicularToAngle = 0;
            double totalAtPole = 0;

            for (int i = 0; i < totalAndAngles.Length; i++)
            {
                totalAtAnlge += totalAndAngles[i].Item1 * (Math.Cos((totalAndAngles[i].Item2 - angle) * 2) * 0.75 + 0.25);
                totalPerpendicularToAngle += totalAndAngles[i].Item1 * (Math.Cos((totalAndAngles[i].Item2 - angle) * 2 + Math.PI) * 0.75 + 0.25);
                totalAtPole += totalAndAngles[i].Item1 * -0.5;
            }

            if (totalAtAnlge < totalPerpendicularToAngle * (1 + neepTideTollerance) && totalAtAnlge > totalPerpendicularToAngle * (1 - neepTideTollerance))
            {
                return (totalAtAnlge, totalPerpendicularToAngle, totalAtPole, neepTideAngle);
            }
            else
            {
                return (totalAtAnlge, totalPerpendicularToAngle, totalAtPole, angle);
            }
        }
    }
}
