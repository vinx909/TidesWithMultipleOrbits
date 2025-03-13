﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class Delete : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void Id_WithoutBool_ReturnsFalse_WhenTryingToDelete_WhenEmpty()
        {
            bool result = sut.Delete(1);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Id_WithBool_ReturnsFalse_WhenTryingToDelete_WhenEmpty(bool boolean)
        {
            bool result = sut.Delete(1, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Id_WithoBool_ReturnTrue_WhenDeletingExistingIdWithoutReference()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubTwo.Id);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Id_WithBool_ReturnTrue_WhenDeletingExistingIdWithoutReference(bool boolean)
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubTwo.Id, boolean);

            Assert.True(result);
        }

        [Fact]
        public void Id_WithoutBool_GetReturnsNull_AfterDeletingExistingIdWithoutReference()
        {
            Populate();
            int targetId = ContainingOrbiterSubTwo.Id;

            sut.Delete(targetId);
            var result = sut.Get(targetId);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Id_WithBool_GetReturnsNull_AfterDeletingExistingIdWithoutReference(bool boolean)
        {
            Populate();
            int targetId = ContainingOrbiterSubTwo.Id;

            sut.Delete(targetId, boolean);
            var result = sut.Get(targetId);

            Assert.Null(result);
        }

        [Fact]
        public void Id_WithoutBool_ReturnsFalse_WhenDeletingExistingIdWithReferences()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne.Id);

            Assert.False(result);
        }

        [Fact]
        public void Id_WithBool_ReturnsFalse_WhenDeletingExistingIdWithReferences_UpdateFalse()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne.Id, false);

            Assert.False(result);
        }

        [Fact]
        public void Id_WithBool_ReturnsTrue_WhenDeletingExistingIdWithReferences_UpdateTrue()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne.Id, true);

            Assert.True(result);
        }

        [Fact]
        public void Id_WithoutBool_GetReturnsSame_WhenDeletingExistingIdWithReferences()
        {
            Populate();
            var target = ContainingOrbiterSubOne;

            sut.Delete(target.Id);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Id_WithBool_GetReturnsSame_WhenDeletingExistingIdWithReferences_UpdateFalse()
        {
            Populate();
            var target = ContainingOrbiterSubOne;

            sut.Delete(target.Id, false);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Id_WithBool_GetReturnsNull_AfterDeletingExistingIdWithReferences_UpdateTrue()
        {
            Populate();
            int targetId = ContainingOrbiterSubOne.Id;

            sut.Delete(targetId, true);
            var result = sut.Get(targetId);

            Assert.Null(result);
        }

        [Fact]
        public void Id_WithBool_GetReturnsItemWithUpdatedReference_AfterDeletingExistingIdWithReferences_UpdateTrue()
        {
            Populate();
            int targetId = ContainingOrbiterSubOne.Id;
            Entities.OrbitItem toBeUpdated = ContainingOrbiterSubSubOne;

            sut.Delete(targetId, true);

            Assert.Equal(0, ContainingOrbiterSubSubOne.OrbitingId);
        }

        [Fact]
        public void Id_WithoutBool_ReturnFalse_WhenTryingToDeleteNotExistingId_WhenPopulated()
        {
            Populate();

            bool result = sut.Delete(NotContainingOrbiterSubThree.Id);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Id_WithBool_ReturnFalse_WhenTryingToDeleteNotExistingId_WhenPopulated(bool boolean)
        {
            Populate();

            bool result = sut.Delete(NotContainingOrbiterSubThree.Id, boolean);

            Assert.False(result);
        }


        [Fact]
        public void Entity_WithoutBool_ReturnsFalse_WhenTryingToDelete_WhenEmpty()
        {
            bool result = sut.Delete(NotContainingOrbiterThree);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnsFalse_WhenTryingToDelete_WhenEmpty(bool boolean)
        {
            bool result = sut.Delete(NotContainingOrbiterThree, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnTrue_WhenDeletingExistingWithoutReference()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubTwo);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnTrue_WhenDeletingExistingWithoutReference(bool boolean)
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubTwo, boolean);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsNull_AfterDeletingExistingWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;

            sut.Delete(target);
            var result = sut.Get(target.Id);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsNull_AfterDeletingExistingWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;

            sut.Delete(target, boolean);
            var result = sut.Get(target.Id);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectIdWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id= ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectIdWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectIdWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectIdWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectNameWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name + " but incorrect", OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectNameWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name + " but incorrect", OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectNameWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name + " but incorrect", OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectNameWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name + " but incorrect", OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectOrbitingIdWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId + 2, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectOrbitingIdWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId + 2, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitingIdWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId + 2, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitingIdWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId + 2, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectMassWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass + 2, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectMassWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass + 2, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectMassWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass + 2, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectMassWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass + 2, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectRadiusWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius + 2, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectRadiusWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius + 2, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectRadiusWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius + 2, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectRadiusWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius + 2, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectOrbitingDistanceWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance + 2, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectOrbitingDistanceWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance + 2, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitingDistanceWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance + 2, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitingDistanceWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance + 2, OrbitPeriod = target.OrbitPeriod };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFase_WhenDeletingExistingWithIncorrectOrbitPeriodWithoutReference()
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod + 2 };

            bool result = sut.Delete(copy);

            Assert.True(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenDeletingExistingWithIncorrectOrbitPeriodWithoutReference(bool boolean)
        {
            Populate();
            Entities.OrbitItem copy = new() { Id = ContainingOrbiterSubTwo.Id, Name = ContainingOrbiterSubTwo.Name, OrbitingId = ContainingOrbiterSubTwo.OrbitingId, Mass = ContainingOrbiterSubTwo.Mass, Radius = ContainingOrbiterSubTwo.Radius, OrbitingDistance = ContainingOrbiterSubTwo.OrbitingDistance, OrbitPeriod = ContainingOrbiterSubTwo.OrbitPeriod + 2 };

            bool result = sut.Delete(copy, boolean);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitPeriodWithoutReference()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod + 2 };

            sut.Delete(copy);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_GetReturnsSame_AfterDeletingExistingWithIncorrectOrbitPeriodWithoutReference(bool boolean)
        {
            Populate();
            var target = ContainingOrbiterSubTwo;
            Entities.OrbitItem copy = new() { Id = target.Id, Name = target.Name, OrbitingId = target.OrbitingId, Mass = target.Mass, Radius = target.Radius, OrbitingDistance = target.OrbitingDistance, OrbitPeriod = target.OrbitPeriod + 2 };

            sut.Delete(copy, boolean);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnsFalse_WhenDeletingExistingWithReferences()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithBool_ReturnsFalse_WhenDeletingExistingWithReferences_UpdateFalse()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne, false);

            Assert.False(result);
        }

        [Fact]
        public void Entity_WithBool_ReturnsTrue_WhenDeletingExistingWithReferences_UpdateTrue()
        {
            Populate();

            bool result = sut.Delete(ContainingOrbiterSubOne, true);

            Assert.True(result);
        }

        [Fact]
        public void Entity_WithoutBool_GetReturnsSame_WhenDeletingExistingWithReferences()
        {
            Populate();
            var target = ContainingOrbiterSubOne;

            sut.Delete(target);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithBool_GetReturnsSame_WhenDeletingExistingWithReferences_UpdateFalse()
        {
            Populate();
            var target = ContainingOrbiterSubOne;

            sut.Delete(target, false);
            var result = sut.Get(target.Id);

            Assert.Equal(target, result);
        }

        [Fact]
        public void Entity_WithBool_GetReturnsNull_AfterDeletingExistingWithReferences_UpdateTrue()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;

            sut.Delete(target, true);
            var result = sut.Get(target.Id);

            Assert.Null(result);
        }

        [Fact]
        public void Entity_WithBool_GetReturnsItemWithUpdatedReference_AfterDeletingExistingWithReferences_UpdateTrue()
        {
            Populate();
            Entities.OrbitItem target = ContainingOrbiterSubOne;
            Entities.OrbitItem toBeUpdated = ContainingOrbiterSubSubOne;

            sut.Delete(target, true);

            Assert.Equal(0, ContainingOrbiterSubSubOne.OrbitingId);
        }

        [Fact]
        public void Entity_WithoutBool_ReturnFalse_WhenTryingToDeleteNotExisting_WhenPopulated()
        {
            Populate();

            bool result = sut.Delete(NotContainingOrbiterSubThree);

            Assert.False(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Entity_WithBool_ReturnFalse_WhenTryingToDeleteNotExisting_WhenPopulated(bool boolean)
        {
            Populate();

            bool result = sut.Delete(NotContainingOrbiterSubThree, boolean);

            Assert.False(result);
        }
    }
}
