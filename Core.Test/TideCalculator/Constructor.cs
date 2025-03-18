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

        [Fact]
        public void ThrowsExceptionWhenIOrbitItemsRepositoryIsNull()
        {
            Mock<IWriter> mockWriter = new();

            Assert.Throws< ArgumentNullException>(() => new Service.TideCalculator(null, mockWriter.Object));
        }

        [Fact]
        public void ThrowsExceptionWhenIWriterIsNull()
        {
            Mock<IOrbitItemsRepository> mockItemsRepository = new();

            Assert.Throws<ArgumentNullException>(() => new Service.TideCalculator(mockItemsRepository.Object, null));
        }
    }
}
