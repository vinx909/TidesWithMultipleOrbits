using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Update : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void ReturnFalse_WhenUpdatingFromEmpty()
        {
            bool result = sut.Update(ContainingNotOrbiterOne);

            Assert.False(result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingMultipleFromEmpty()
        {
            Entities.OrbitItem[] toUpdate = { ContainingNotOrbiterOne, NotContainingNotOrbiterTwo };

            bool result = sut.Update(toUpdate);

            Assert.False(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingName()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name + " edit", OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleNames()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name + " edit", OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name + " edit two", OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingName()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleNames()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name + " edit", OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name + " edit two", OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingOrbitingId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubTwo.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleOrbitingIds()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = ContainingOrbiterSubTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = ContainingOrbiterTwo.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingOrbitingId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubTwo.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleOrbitingIds()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = ContainingOrbiterSubTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = ContainingOrbiterTwo.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMass()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass + 2 , Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleMasses()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass + 2 , Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass + 3 , Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMass()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass + 2 , Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleMasses()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass + 2 , Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass + 3 , Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingRadius()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius + 2 , OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleRadiuses()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius + 2, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius + 3, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingRadius()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius + 2, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleRadiuses()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius + 2 , OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius + 3 , OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingOrbitingDistance()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance + 2, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleOrbitingDistances()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance + 2 , OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance + 3 , OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingOrbitingDistance()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance + 2 , OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleOrbitingDistances()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance + 2 , OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance + 3 , OrbitPeriod = targetTwo.OrbitPeriod } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingOrbitPeriod()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod + 2 };

            bool result = sut.Update(updateItem);

            Assert.True(result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleOrbitPeriods()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod + 2 }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod + 3 } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingOrbitPeriod()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubSubOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod + 2 };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(updateItem.Name, result.Name);
            Assert.Equal(updateItem.OrbitingId, result.OrbitingId);
            Assert.Equal(updateItem.Mass, result.Mass);
            Assert.Equal(updateItem.Radius, result.Radius);
            Assert.Equal(updateItem.OrbitingDistance, result.OrbitingDistance);
            Assert.Equal(updateItem.OrbitPeriod, result.OrbitPeriod);
        }

        [Fact]
        public void GetReturnsItemWithAlteredData_WhenUpdatingMultipleOrbitPeriods()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubOne;
            Entities.OrbitItem[] toUpdate = {
                new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetOne.OrbitingId, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance + 3, OrbitPeriod = targetOne.OrbitPeriod + 2 },
                new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetTwo.OrbitingId, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance + 3, OrbitPeriod = targetTwo.OrbitPeriod + 3 } };
            Entities.OrbitItem[] results = new Entities.OrbitItem[toUpdate.Length];

            sut.Update(toUpdate);
            for (int i = 0; i < toUpdate.Length; i++)
            {
                results[i] = sut.Get(toUpdate[i].Id);
            }

            for (int i = 0; i < toUpdate.Length; i++)
            {
                Assert.Equal(toUpdate[i].Name, results[i].Name);
                Assert.Equal(toUpdate[i].OrbitingId, results[i].OrbitingId);
                Assert.Equal(toUpdate[i].Mass, results[i].Mass);
                Assert.Equal(toUpdate[i].Radius, results[i].Radius);
                Assert.Equal(toUpdate[i].OrbitingDistance, results[i].OrbitingDistance);
                Assert.Equal(toUpdate[i].OrbitPeriod, results[i].OrbitPeriod);
            }
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingOrbitingIdToFininiteLoop()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubSubOne.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.False(result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingMultipleOrbitingIdToFininiteLoop()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubSubOne.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsItemWithOrigionalData_WhenUpdatingOrbitingIdToFininiteLoop()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            int origionalOrbitingId = target.OrbitingId;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubSubOne.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(origionalOrbitingId, result.OrbitingId);
        }

        [Fact]
        public void GetReturnsItemWithOrigionalData_WhenUpdatingMultipleOrbitingIdsToFininiteLoop()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            int origionalOrbitingId = target.OrbitingId;
            Entities.OrbitItem[] toUpdate = { new() { Id = target.Id, Name = target.Name, OrbitingId = ContainingOrbiterSubSubOne.Id, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod } };

            sut.Update(toUpdate);
            var result = sut.Get(target.Id);

            Assert.Equal(origionalOrbitingId, result.OrbitingId);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingOrbitingIdToNonExisting()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = 99, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            bool result = sut.Update(updateItem);

            Assert.False(result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingMultipleOrbitingIdToNonExisting()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = target.Id, Name = target.Name, OrbitingId = 99, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsItemWithOrigionalData_WhenUpdatingOrbitingIdToNonExisting()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            int origionalOrbitingId = target.OrbitingId;
            Entities.OrbitItem updateItem = new() { Id = target.Id, Name = target.Name, OrbitingId = 99, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Update(updateItem);
            Entities.OrbitItem result = sut.Get(updateItem.Id);

            Assert.Equal(origionalOrbitingId, result.OrbitingId);
        }

        [Fact]
        public void GetReturnsItemWithOrigionalData_WhenUpdatingMultipleOrbitingIdsToNonExisting()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;
            int origionalOrbitingId = target.OrbitingId;
            Entities.OrbitItem[] toUpdate = { new() { Id = target.Id, Name = target.Name, OrbitingId = 99, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod } };

            sut.Update(toUpdate);
            var result = sut.Get(target.Id);

            Assert.Equal(origionalOrbitingId, result.OrbitingId);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingMultipleOrbitingIdToEachOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterTwo;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.False(result);
        }

        [Fact]
        public void GetReturnsItemWithOrigionalData_WhenUpdatingMultipleOrbitingIdsToEachOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterTwo;
            int originalOrbitingIdOne = targetOne.OrbitingId;
            int originalOrbitingIdTwo = targetTwo.OrbitingId;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            sut.Update(toUpdate);
            var resultOne = sut.Get(targetOne.Id);
            var resultTwo = sut.Get(targetTwo.Id);

            Assert.Equal(originalOrbitingIdOne, resultOne.OrbitingId);
            Assert.Equal(originalOrbitingIdTwo, resultTwo.OrbitingId);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleOrbitingIdToEachOtherAndOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubTwo;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = ContainingNotOrbiterOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAltereData_WhenUpdatingMultipleOrbitingIdsToEachOtherAndOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubTwo;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = targetTwo.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = ContainingNotOrbiterOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            sut.Update(toUpdate);
            var resultOne = sut.Get(targetOne.Id);
            var resultTwo = sut.Get(targetTwo.Id);

            Assert.Equal(toUpdate[0].OrbitingId, resultOne.OrbitingId);
            Assert.Equal(toUpdate[1].OrbitingId, resultTwo.OrbitingId);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingMultipleOrbitingIdToOtherAndEachOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubSubOne;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubTwo;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = ContainingNotOrbiterOne.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            bool result = sut.Update(toUpdate);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsItemWithAltereData_WhenUpdatingMultipleOrbitingIdsToOtherAndEachOther()
        {
            Populate();
            Entities.OrbitItem targetOne = ContainingOrbiterSubTwo;
            Entities.OrbitItem targetTwo = ContainingOrbiterSubSubOne;
            Entities.OrbitItem[] toUpdate = { new() { Id = targetOne.Id, Name = targetOne.Name, OrbitingId = ContainingNotOrbiterOne.Id, Mass = targetOne.Mass, Radius = targetOne.Radius, OrbitingDistance = targetOne.OrbitingDistance, OrbitPeriod = targetOne.OrbitPeriod }, new() { Id = targetTwo.Id, Name = targetTwo.Name, OrbitingId = targetOne.Id, Mass = targetTwo.Mass, Radius = targetTwo.Radius, OrbitingDistance = targetTwo.OrbitingDistance, OrbitPeriod = targetTwo.OrbitPeriod } };

            sut.Update(toUpdate);
            var resultOne = sut.Get(targetOne.Id);
            var resultTwo = sut.Get(targetTwo.Id);

            Assert.Equal(toUpdate[0].OrbitingId, resultOne.OrbitingId);
            Assert.Equal(toUpdate[1].OrbitingId, resultTwo.OrbitingId);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingToWhatItIs()
        {
            Populate();

            bool result = sut.Update(ContainingNotOrbiterOne);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsSame_WhenUpdatingToWhatItIs()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;

            sut.Update(target);
            var result = sut.Get(target.Id);

            IsSameOrbitItem(target, result);
        }

        [Fact]
        public void ReturnTrue_WhenUpdatingToWhatItIs_IEnumerable()
        {
            Populate();

            bool result = sut.Update([ContainingNotOrbiterOne]);

            Assert.True(result);
        }

        [Fact]
        public void GetReturnsSame_WhenUpdatingToWhatItIs_IEnumerable()
        {
            Populate();
            Entities.OrbitItem target = ContainingNotOrbiterOne;

            sut.Update([target]);
            var result = sut.Get(target.Id);

            IsSameOrbitItem(target, result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenId()
        {
            Populate();
            var origional = ContainingOrbiterOne;
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;

            bool result = sut.Update(copy);

            Assert.False(result);
        }

        [Fact]
        public void ReturnOrigional_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenId()
        {
            Populate();
            var origional = Copy(ContainingOrbiterOne);
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;

            sut.Update(copy);
            var result = sut.Get(origional.Id);

            IsSameOrbitItem(origional, result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenId_IEnumerable()
        {
            Populate();
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = ContainingOrbiterOne.Id;

            bool result = sut.Update([copy]);

            Assert.False(result);
        }

        [Fact]
        public void ReturnOrigional_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenId_IEnumerable()
        {
            Populate();
            var origional = Copy(ContainingOrbiterOne);
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;

            sut.Update(copy);
            var result = sut.Get(origional.Id);

            IsSameOrbitItem(origional, result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenIdAndOrbitingId()
        {
            Populate();
            var origional = ContainingOrbiterOne;
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;
            copy.OrbitingId = origional.OrbitingId;

            bool result = sut.Update(copy);

            Assert.False(result);
        }

        [Fact]
        public void ReturnOrigional_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenIdAndOrbitingId()
        {
            Populate();
            var origional = Copy(ContainingOrbiterOne);
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;
            copy.OrbitingId = origional.OrbitingId;

            sut.Update(copy);
            var result = sut.Get(origional.Id);

            IsSameOrbitItem(origional, result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenIdAndOrbitingId_IEnumerable()
        {
            Populate();
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = ContainingOrbiterOne.Id;
            copy.OrbitingId = mirrored.OrbitingId;

            bool result = sut.Update([copy]);

            Assert.False(result);
        }

        [Fact]
        public void ReturnOrigional_WhenUpdatingToHaveValuesOfAnotherEntityOtherThenIdAndOrbitingId_IEnumerable()
        {
            Populate();
            var origional = Copy(ContainingOrbiterOne);
            var mirrored = ContainingOrbiterTwo;
            var copy = Copy(mirrored);
            copy.Id = origional.Id;
            copy.OrbitingId = origional.OrbitingId;

            sut.Update(copy);
            var result = sut.Get(origional.Id);

            IsSameOrbitItem(origional, result);
        }

        [Fact]
        public void ReturnFalse_WhenUpdatingToHaveValuesOfEachotherThenIdAndOrbitingId()
        {
            Populate();
            var copyOne = Copy(ContainingOrbiterOne);
            var copyTwo = Copy(ContainingOrbiterTwo);
            copyOne.Name = copyTwo.Name;
            copyTwo.OrbitingId = copyOne.OrbitingId;
            copyOne.Mass = copyTwo.Mass;
            copyTwo.Radius = copyOne.Radius;
            copyOne.OrbitingDistance = copyTwo.OrbitingDistance;
            copyTwo.OrbitPeriod = copyOne.OrbitPeriod;

            bool result = sut.Update([copyOne, copyTwo]);

            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void ReturnOrigionals_WhenUpdatingToHaveValuesOfEachotherThenIdAndOrbitingId(int id)
        {
            Populate();
            var copyOne = Copy(ContainingOrbiterOne);
            var copyTwo = Copy(ContainingOrbiterTwo);
            copyOne.Name = copyTwo.Name;
            copyTwo.OrbitingId = copyOne.OrbitingId;
            copyOne.Mass = copyTwo.Mass;
            copyTwo.Radius = copyOne.Radius;
            copyOne.OrbitingDistance = copyTwo.OrbitingDistance;
            copyTwo.OrbitPeriod = copyOne.OrbitPeriod;

            sut.Update([copyOne, copyTwo]);
            var result = sut.Get(id);

            if (id == 2 && ContainingOrbiterOne.Id == 2)
            {
                IsSameOrbitItem(ContainingOrbiterOne, result);
            }
            else if (id == 3 && ContainingOrbiterTwo.Id == 3)
            {
                IsSameOrbitItem(ContainingOrbiterTwo, result);
            }
            else
            {
                throw new InvalidOperationException("this means that the testing data has been altered, which in turn means that the tests need to be updated");
            }
        }
    }
}
