using Service = Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.Writer
{
    public class Constructor
    {
        [Fact]
        public void CanConstruct()
        {
            var sut = new Service.Writer();

            Assert.IsType<Service.Writer>(sut);
        }
    }
}
