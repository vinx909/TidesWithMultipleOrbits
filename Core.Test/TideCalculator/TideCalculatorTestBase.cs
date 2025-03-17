using Service = Core.Services;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Core.Test.TideCalculator
{
    public class TideCalculatorTestBase
    {
        protected ITideCalculator sut;

        protected Mock<IOrbitItemsRepository> mockItemsRepository;
        protected Mock<IWriter> mockWriter;

        public TideCalculatorTestBase()
        {
            mockItemsRepository = new();
            mockWriter = new();

            sut = new Service.TideCalculator(mockItemsRepository.Object, mockWriter.Object);
        }
    }
}
