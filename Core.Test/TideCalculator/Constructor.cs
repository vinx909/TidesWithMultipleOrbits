using Service = Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Moq;

namespace Core.Test.TideCalculator
{
    public class Constructor
    {
        [Fact]
        public void CanConstruct()
        {
            Mock<IOrbitItemsRepository> mockItemsRepository = new();
            Mock<IWriter> mockWriter = new();

            var result = new Service.TideCalculator(mockItemsRepository.Object, mockWriter.Object);

            Assert.IsType<Service.TideCalculator>(result);
        }
    }
}
