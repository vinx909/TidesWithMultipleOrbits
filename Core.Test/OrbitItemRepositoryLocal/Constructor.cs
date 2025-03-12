using Service = Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Constructor
    {
        [Fact]
        public void CanConstruct()
        {
            var sut = new Service.OrbitItemRepositoryLocal();

            Assert.IsType<Service.OrbitItemRepositoryLocal>(sut);
        }
    }
}
