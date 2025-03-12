using Service = Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public abstract class OrbitItemRepositoryLocalTestBase : OrbitItemTestData
    {
        private static readonly Exception failedToPopulateException = new Exception("failed to add items with the method Add(IEnumerable<OrbitItem>) making the running of this test impossible");

        protected IObitItemsRepository sut;

        protected OrbitItemRepositoryLocalTestBase()
        {
            sut = new Service.OrbitItemRepositoryLocal();
        }

        protected void Populate()
        {
            try
            {
                if (!sut.Add(ContainedOrbitItems))
                {
                    throw failedToPopulateException;
                }
            }
            catch (Exception ex)
            {
                throw failedToPopulateException;
            }
            
        }
    }
}
