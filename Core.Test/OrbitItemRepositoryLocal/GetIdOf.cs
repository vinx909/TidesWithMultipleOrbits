using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class GetIdOf : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void WithoutBool_ReturnsNull_WhenEmpty()
        {
            int? result = sut.GetIdOf(ContainingOrbiterOne);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WhenEmpty(bool boolean)
        {
            int? result = sut.GetIdOf(ContainingOrbiterOne, boolean);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_WhenFilled()
        {
            Populate();

            int? result = sut.GetIdOf(ContainingOrbiterOne);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_WhenFilled(bool boolean)
        {
            Populate();

            int? result = sut.GetIdOf(ContainingOrbiterOne, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsCorrectId_WhenFilled()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;

            int? result = sut.GetIdOf(target);

            Assert.Equal(target.Id, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsCorrectId_WhenFilled(bool boolean)
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;

            int? result = sut.GetIdOf(target, boolean);

            Assert.Equal(target.Id, result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_WithIncorrectId()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = copy.Id+10;

            int? result = sut.GetIdOf(copy);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_WithIncorrectId(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Id = copy.Id + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsCorrectId_WithIncorrectId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;
            var copy = Copy(target);
            copy.Id = copy.Id + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Equal(target.Id, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsCorrectId_WithIncorrectId(bool boolean)
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;
            var copy = Copy(target);
            copy.Id = copy.Id + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Equal(target.Id, result);
        }

        [Fact]
        public void WithoutBool_ReturnsNull_WithIncorrectName()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Name = copy.Name + " but incorrect";

            int? result = sut.GetIdOf(copy);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WithIncorrectName(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Name = copy.Name + " but incorrect";

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_WithIncorrectOrbitingId()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 10;

            int? result = sut.GetIdOf(copy);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithBool_ReturnsNotNull_WithIncorrectOrbitingId_CheckOrbitingIdFalse()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 10;

            int? result = sut.GetIdOf(copy, false);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithBool_ReturnsNull_WithIncorrectOrbitingId_CheckOrbitingIdTrue()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitingId = copy.OrbitingId + 10;

            int? result = sut.GetIdOf(copy, true);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsCorrectId_WithIncorrectOrbitingId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;
            var copy = Copy(target);
            copy.OrbitingId = copy.OrbitingId + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Equal(target.Id, result);
        }

        [Fact]
        public void WithBool_ReturnsCorrectId_WithIncorrectOrbitingId_CheckOrbitingIdFalse()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterOne;
            var copy = Copy(target);
            copy.OrbitingId = copy.OrbitingId + 10;

            int? result = sut.GetIdOf(copy, false);

            Assert.Equal(target.Id, result);
        }

        [Fact]
        public void WithoutBool_ReturnsNull_WithIncorrectMass()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Mass = copy.Mass + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WithIncorrectMass(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Mass = copy.Mass + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNull_WithIncorrectRadius()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Radius = copy.Radius + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WithIncorrectRadius(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.Radius = copy.Radius + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNull_WithIncorrectOrbitingDistance()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitingDistance = copy.OrbitingDistance + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WithIncorrectOrbitingDistance(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitingDistance = copy.OrbitingDistance + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Null(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNull_WithIncorrectOrbitPeriod()
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitPeriod = copy.OrbitPeriod + 10;

            int? result = sut.GetIdOf(copy);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNull_WithIncorrectOrbitPeriod(bool boolean)
        {
            Populate();
            var copy = Copy(ContainingOrbiterOne);
            copy.OrbitPeriod = copy.OrbitPeriod + 10;

            int? result = sut.GetIdOf(copy, boolean);

            Assert.Null(result);
        }
    }
}
