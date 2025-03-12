using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Test.OrbitItemRepositoryLocal
{
    public class GetAllOrbitersOf : OrbitItemRepositoryLocalTestBase
    {
        [Fact]
        public void WithoutBool_ReturnsNotNull_IfEmpty()
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_IfEmpty(bool boolean)
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsIEnumerable_IfEmpty()
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsIEnumerable_IfEmpty(bool boolean)
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void WithoutBool_ReturnsEmptyIEnumerable_IfEmpty()
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsEmptyIEnumerable_IfEmpty(bool boolean)
        {
            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.Empty(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_IfPopulated_WithExistingId_WithOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_IfPopulated_WithExistingId_WithOrbiter(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_IfPopulated_WithExistingId_WithoutOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_IfPopulated_WithExistingId_WithoutOrbiter(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsNotNull_IfPopulated_WithNotExistingId()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsNotNull_IfPopulated_WithNotExistingId(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id, boolean);

            Assert.NotNull(result);
        }

        [Fact]
        public void WithoutBool_ReturnsIEnumerable_IfPopulated_WithExistingId_WithOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsIEnumerable_IfPopulated_WithExistingId_WithOrbiter(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void WithoutBool_ReturnsIEnumerable_IfPopulated_WithExistingId_WithoutOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsIEnumerable_IfPopulated_WithExistingId_WithoutOrbiters(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id, boolean);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void WithoutBool_ReturnsIEnumerable_IfPopulated_WithNotExistingId()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsIEnumerable_IfPopulated_WithNotExistingId(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id, boolean);

            Assert.IsAssignableFrom<IEnumerable<Entities.OrbitItem>>(result);
        }

        [Fact]
        public void WithoutBool_ReturnsFilledIEnumerable_IfPopulated_WithExistingId_WithOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsFilledIEnumerable_IfPopulated_WithExistingId_WithOrbiter(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, boolean);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void WithoutBool_ReturnsEmptyIEnumerable_IfPopulated_WithExistingId_WithoutOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsEmptyIEnumerable_IfPopulated_WithExistingId_WithoutOrbiters(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterTwo.Id, boolean);

            Assert.Empty(result);
        }

        [Fact]
        public void WithoutBool_ReturnsEmptyIEnumerable_IfPopulated_WithNotExistingId()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id);

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithBool_ReturnsEmptyIEnumerable_IfPopulated_WithNotExistingId(bool boolean)
        {
            Populate();

            var result = sut.GetAllOrbitersOf(NotContainingOrbiterThree.Id, boolean);

            Assert.Empty(result);
        }

        [Fact]
        public void WithoutBool_ReturnsCorrectAmount_IfPopulated_WithExistingId_WithOrbiters()
        {
            const int expectedNumberOfOrbiters = 3;
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.Equal(expectedNumberOfOrbiters, result.Count());
        }

        [Fact]
        public void WithBool_ReturnsCorrectAmount_IfPopulated_WithExistingId_WithOrbiter_WithSuborbiters()
        {
            const int expectedNumberOfOrbiters = 3;
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, true);

            Assert.Equal(expectedNumberOfOrbiters, result.Count());
        }

        [Fact]
        public void WithBool_ReturnsCorrectAmount_IfPopulated_WithExistingId_WithOrbiter_WithoutSuborbiters()
        {
            const int expectedNumberOfOrbiters = 2;
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, false);

            Assert.Equal(expectedNumberOfOrbiters, result.Count());
        }
        
        [Fact]
        public void WithoutBool_ReturnsCorrectItems_IfPopulated_WithExistingId_WithOrbiters()
        {
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id);

            Assert.Contains(ContainingOrbiterSubOne, result);
            Assert.Contains(ContainingOrbiterSubTwo, result);
            Assert.Contains(ContainingOrbiterSubSubOne, result);
        }

        [Fact]
        public void WithBool_ReturnsCorrectItems_IfPopulated_WithExistingId_WithOrbiter_WithSuborbiters()
        {
            const int expectedNumberOfOrbiters = 3;
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, true);

            Assert.Contains(ContainingOrbiterSubOne, result);
            Assert.Contains(ContainingOrbiterSubTwo, result);
            Assert.Contains(ContainingOrbiterSubSubOne, result);
        }

        [Fact]
        public void WithBool_ReturnsCorrectItems_IfPopulated_WithExistingId_WithOrbiter_WithoutSuborbiters()
        {
            const int expectedNumberOfOrbiters = 2;
            Populate();

            var result = sut.GetAllOrbitersOf(ContainingOrbiterOne.Id, false);

            Assert.Contains(ContainingOrbiterSubOne, result);
            Assert.Contains(ContainingOrbiterSubTwo, result);
        }
    }
}
