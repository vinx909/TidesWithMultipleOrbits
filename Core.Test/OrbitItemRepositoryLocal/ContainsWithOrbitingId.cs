using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class ContainsWithOrbitingId : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void Id_ReturnsNull_IfEmpty()
        {
            int? result = sut.ContainsWithOrbitingId(ContainingOrbiterSubOne.Id);

            Assert.Null(result);
        }

        [Fact]
        public void Id_ReturnsNotNull_IfContaining()
        {
            Populate();

            int? result = sut.ContainsWithOrbitingId(ContainingOrbiterSubOne.Id);

            Assert.NotNull(result);
        }

        [Fact]
        public void Id_ReturnsCorrectId_IfContaining()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;

            int? result = sut.ContainsWithOrbitingId(target.Id);

            Assert.Equal(target.OrbitingId ,result);
        }

        [Fact]
        public void Id_ReturnsNull_IfNotContainingWhenFilled()
        {
            Populate();

            int? result = sut.ContainsWithOrbitingId(NotContainingOrbiterSubThree.Id);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfEmpty()
        {
            int? result = sut.ContainsWithOrbitingId(ContainingOrbiterSubOne);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNotNull_IfContaining()
        {
            Populate();

            int? result = sut.ContainsWithOrbitingId(ContainingOrbiterSubOne);

            Assert.NotNull(result);
        }

        [Fact]
        public void Entity_ReturnsCorrectId_IfContaining()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;

            int? result = sut.ContainsWithOrbitingId(target);

            Assert.Equal(target.OrbitingId, result);
        }

        [Fact]
        public void Entity_ReturnsNotNull_IfContainingIncorrectId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.Id = copy.Id + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.NotNull(result);
        }

        [Fact]
        public void Entity_ReturnsCorrectId_IfContainingIncorrectId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.Id = copy.Id + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Equal(target.OrbitingId, result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfContainingIncorrectName()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.Name = copy.Name + " but incorrect";

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNotNull_IfContainingIncorrectOrbitingId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.OrbitingId = copy.OrbitingId + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.NotNull(result);
        }

        [Fact]
        public void Entity_ReturnsCorrectId_IfContainingIncorrectOrbitingId()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.OrbitingId = copy.OrbitingId + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Equal(target.OrbitingId, result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfContainingIncorrectMass()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.Mass = copy.Mass + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfContainingIncorrectRadius()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.Radius = copy.Radius + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfContainingIncorrectOrbitingDistance()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.OrbitingDistance = copy.OrbitingDistance + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfContainingIncorrectOrbitPeriod()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem copy = Copy(target);
            copy.OrbitPeriod = copy.OrbitPeriod + 2;

            int? result = sut.ContainsWithOrbitingId(copy);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_ReturnsNull_IfNotContainingWhenFilled()
        {
            Populate();

            int? result = sut.ContainsWithOrbitingId(NotContainingNotOrbiterTwo);

            Assert.Null(result);
        }
    }
}
