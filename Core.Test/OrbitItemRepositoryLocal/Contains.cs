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
            bool result = sut.Contains(ContainingOrbiterOne.Id);

            Assert.False(result);
        }

        [Fact]
        public void Id_ReturnsTrue_IfContaining()
        {
            Populate();

            bool result = sut.Contains(ContainingOrbiterOne.Id);

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
            bool result = sut.Contains(ContainingOrbiterOne);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContaining()
        {
            Populate();

            bool result = sut.Contains(ContainingOrbiterOne);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContainingIncorrectId()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Id = copy.Id + 2;

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectName()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Name = copy.Name + " but incorrect";

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsTrue_IfContainingIncorrectOrbitingId()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 2;

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectMass()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Mass = copy.Mass + 2;

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectRadius()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Radius = copy.Radius + 2;

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectOrbitingDistance()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitingDistance = copy.OrbitingDistance + 2;

            bool result = sut.Contains(copy);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBoolean_ReturnsFalse_IfContainingIncorrectOrbitPeriod()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitPeriod = copy.OrbitPeriod + 2;

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
            bool result = sut.Contains(ContainingOrbiterOne, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsTrue_IfContaining(bool boolean)
        {
            Populate();

            bool result = sut.Contains(ContainingOrbiterOne, boolean);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsTrue_IfContainingIncorrectId(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Id = copy.Id + 2;

            bool result = sut.Contains(copy, boolean);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectName(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Name = copy.Name + " but incorrect";

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithBoolean_ReturnsTrue_IfContainingIncorrectOrbitingId_CheckOrbitingIdFalse()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 2;

            bool result = sut.Contains(copy);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitingId_CheckOrbitingIdTrue()
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 2;

            bool result = sut.Contains(copy, true);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectMass(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Mass = copy.Mass + 2;

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectRadius(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.Radius = copy.Radius + 2;

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitingDistance(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitingDistance = copy.OrbitingDistance + 2;

            bool result = sut.Contains(copy, boolean);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBoolean_ReturnsFalse_IfContainingIncorrectOrbitPeriod(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = Copy(ContainingOrbiterOne);
            copy.OrbitPeriod = copy.OrbitPeriod + 2;

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
