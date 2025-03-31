using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrbitItem
    {
        private int id = -1;
        private int orbitingId = -1;
        private double mass = -1;
        private int radius = -1;
        private long orbitingDistance = -1;
        private int orbitPeriod = -1;

        /// <summary>
        /// the id of the item. can't have an id of 0 as that is reserved for items that don't orbit
        /// </summary>
        public int Id { get => id; set { if (value != id && value > 0) { id = value; } } }

        public string Name { get; set; }

        /// <summary>
        /// the id of the item this item orbits. 0 is an item that doesn't orbit
        /// </summary>
        public int OrbitingId
        {
            get => orbitingId;
            set 
            {
                if (value != orbitingId && value != Id && value > -1)
                {
                    if(orbitingId == 0 && value != 0)
                    {
                        orbitingId = value;
                        OrbitingDistance = 1;
                    }
                    else
                    {
                        orbitingId = value;
                    }

                    if (value == 0)
                    {
                        OrbitingDistance = 0;
                        OrbitPeriod = 0; 
                    }
                } 
            } 
        }

        /// <summary>
        /// mass in kg
        /// </summary>
        public double Mass
        {
            get => mass;
            set 
            {
                if (value != mass && value > -1) 
                { 
                    mass = value; 
                }
            }
        }

        /// <summary>
        /// radius in meters
        /// </summary>
        public int Radius 
        { 
            get => radius; 
            set 
            { 
                if (value != radius && value > -1) 
                {
                    radius = value; 
                }
            } 
        }

        /// <summary>
        /// distance to the item it's orbiting in meters, must be greater then 0
        /// </summary>
        public long OrbitingDistance
        {
            get => orbitingDistance; 
            set 
            {
                if (value != orbitingDistance && ((OrbitingId == 0 && value == 0) || (OrbitingId != 0 && value > 0))) 
                {
                    orbitingDistance = value; 
                }
            }
        }

        /// <summary>
        /// the amount of time it takes to complete one orbit in arbitrairy units, such as days. 0 is an item that doesn't doesn't, useful for items that do orbit but would change nothing for the calculation
        /// </summary>
        public int OrbitPeriod 
        {
            get => orbitPeriod; 
            set 
            {
                if (value != orbitPeriod && ((OrbitingId == 0 && value == 0) || (OrbitingId != 0 && value > -1))) 
                {
                    orbitPeriod = value;
                }
            }
        }

        public OrbitItem()
        {
            Id = 1;
            Name = string.Empty;
            OrbitingId = 0;
            Mass = 0;
            Radius = 0;
            OrbitingDistance = 1;
            OrbitPeriod = 0;
        }
    }
}
