using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Contains : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void Id_ReturnsFalse_IfEmpty()
        {
            bool result = sut.Contains(ContainingNotOrbiterOne.Id);

            Assert.False(result);
        }

        [Fact]
        public void Id_ReturnsTrue_IfContaining()
        {
            Populate();

            bool result = sut.Contains(ContainingNotOrbiterOne.Id);

            Assert.True(result);
        }

        [Fact]
        public void Id_ReturnsFalse_IfNotContainingWhenFilled()
        {
            Populate();

            bool result = sut.Contains(NotContainingNotOrbiterTwo.Id);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfEmpty()
        {
            bool result = sut.Contains(ContainingNotOrbiterOne);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContaining()
        {
            Populate();

            bool result = sut.Contains(ContainingNotOrbiterOne);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContainingIncorrectId()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id + 2, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectName()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name + " but incorrect", OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContainingIncorrectOrbitingId()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId + 2, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectMass()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass + 2, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectRadius()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius + 2, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectOrbitingDistance()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance + 2, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectOrbitPeriod()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod + 2 };

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfNotContainingWhenFilled()
        {
            Populate();

            bool result = sut.Contains(NotContainingNotOrbiterTwo);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfEmpty(bool boolean)
        {
            bool result = sut.Contains(ContainingNotOrbiterOne, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsTrue_IfContaining(bool boolean)
        {
            Populate();

            bool result = sut.Contains(ContainingNotOrbiterOne, boolean);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsTrue_IfContainingIncorrectId(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id + 2, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, boolean);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectName(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name + " but incorrect", OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithBoolean_ReturnsTrue_IfContainingIncorrectOrbitingId_CheckOrbitingIdFalse()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId + 2, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitingId_CheckOrbitingIdTrue()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId + 2, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, true);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectMass(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass + 2, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectRadius(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius + 2, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitingDistance(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance + 2, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod };

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitPeriod(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingNotOrbiterOne.Id, Name = ContainingNotOrbiterOne.Name, OrbitingId = ContainingNotOrbiterOne.OrbitingId, Mass = ContainingNotOrbiterOne.Mass, Radius = ContainingNotOrbiterOne.Radius, OrbitingDistance = ContainingNotOrbiterOne.OrbitingDistance, OrbitPeriod = ContainingNotOrbiterOne.OrbitPeriod + 2 };

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfNotContainingWhenFilled(bool boolean)
        {
            Populate();

            bool result = sut.Contains(NotContainingNotOrbiterTwo, boolean);

            Assert.False(result);
        }
    }
}
