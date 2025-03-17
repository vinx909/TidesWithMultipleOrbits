using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITideCalculator
    {
        /// <summary>
        /// takes a series of OrbitItems to work with from now on.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool ProvideRangeToWorkWith(IEnumerable<OrbitItem> items);

        /// <summary>
        /// gives the amount of time units until the situation at the start repeats
        /// </summary>
        /// <returns></returns>
        public int TimeTillRestart();

        //todo: deside between using radiance and degrees
        /// <summary>
        /// gets the angle from itemAtZeroDegrees via itemCentral to itemMeasure at a given time
        /// </summary>
        /// <param name="itemCentral"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="itemMeasure"></param>
        /// <param name="time"></param>
        /// <returns>angle in radiance/degrees</returns>
        public double AngleTo(OrbitItem itemCentral, OrbitItem itemAtZeroDegrees, OrbitItem itemMeasure, int time);

        /// <summary>
        /// gets the distance between itemOne and ItemTwo at a given time
        /// </summary>
        /// <param name="ItemOne"></param>
        /// <param name="ItemTwo"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double DistanceBetween(OrbitItem ItemOne, OrbitItem ItemTwo, int time);

        /// <summary>
        /// gets the distance between centralItem and measureItem and the angle from itemAtZeroDegrees via centralItem to measuringItem at a given time
        /// </summary>
        /// <param name="centralItem"></param>
        /// <param name="measuringItem"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public (double, double) DistanceAndAngleBetween(OrbitItem centralItem, OrbitItem measuringItem, OrbitItem itemAtZeroDegrees, int time);

        /// <summary>
        /// returns the amount of tidal force the experiancer experiances from the excerter at a given time
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="excerter"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double TidalForceBetweenTwoBodies(OrbitItem experiancer, OrbitItem excerter, int time);

        /// <summary>
        /// returns the amount of tidal height the experiancer experiances from the excerter at a given time
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="excerter"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double TidalHeightBetweenTwoBodies(OrbitItem experiancer, OrbitItem excerter, int time);

        /// <summary>
        /// returns the total amount of tidal force the experiancer experiances from all items and in what direction the force is at a given time
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public (double, double) TotalTidalForceAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time);

        /// <summary>
        /// returns the total amount of tidal height the experiancer experiances from all items and in what direction the force is at a given time
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public (double, double) TotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time);

        /// <summary>
        /// sets the path to write to in WriteCommands
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true is the path was successfully set, or false if setting the path failed</returns>
        public bool SetWritePath(string path);

        /// <summary>
        /// writes the angle from itemAtZeroDegrees via itemCentral to itemMeasure to a file at different times
        /// </summary>
        /// <param name="itemCentral"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="itemMeasure"></param>
        /// <param name="initialTime"></param>
        /// <param name="finalTime"></param>
        /// <param name="timesteps"></param>
        /// <returns>returns true if successfully written, or false if it failed</returns>
        public bool WriteAngleToFile(OrbitItem itemCentral, OrbitItem itemAtZeroDegrees, OrbitItem itemMeasure, int initialTime, int finalTime, int timesteps);

        /// <summary>
        /// writes the distance between itemOne and ItemTwo to a file at different times
        /// </summary>
        /// <param name="ItemOne"></param>
        /// <param name="ItemTwo"></param>
        /// <param name="initialTime"></param>
        /// <param name="finalTime"></param>
        /// <param name="timesteps"></param>
        /// <returns>returns true if successfully written, or false if it failed</returns>
        public bool WriteDistanceBetweenToFile(OrbitItem ItemOne, OrbitItem ItemTwo, int initialTime, int finalTime, int timesteps);

        /// <summary>
        /// writes distance between centralItem and measureItem and the angle from itemAtZeroDegrees via centralItem to measuringItem to a file at different times
        /// </summary>
        /// <param name="centralItem"></param>
        /// <param name="measuringItem"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="initialTime"></param>
        /// <param name="finalTime"></param>
        /// <param name="timesteps"></param>
        /// <returns>returns true if successfully written, or false if it failed</returns>
        public bool WriteDistanceAndAngleBetweenToFile(OrbitItem centralItem, OrbitItem measuringItem, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps);

        /// <summary>
        /// writes the total tidal force and angle to a file at different times
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="initialTime"></param>
        /// <param name="finalTime"></param>
        /// <param name="timesteps"></param>
        /// <returns>returns true if successfully written, or false if it failed</returns>
        public bool WriteTotalTidalForceAndAngleToFile(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int initialTime, int finalTime, int timesteps);

        /// <summary>
        /// writes the total tidal height and angle to a file at different times
        /// </summary>
        /// <param name="experiancer"></param>
        /// <param name="itemAtZeroDegrees"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool WriteTotalTidalHeightAndAngle(OrbitItem experiancer, OrbitItem itemAtZeroDegrees, int time);
    }
}
