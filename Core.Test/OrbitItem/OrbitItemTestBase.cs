using Entities = Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public abstract class OrbitItemTestBase
    {
        protected Entities.OrbitItem sut;

        public OrbitItemTestBase()
        {
            sut = new();
        }
    }
}
