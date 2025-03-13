﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.OrbitItem
{
    public class OrbitingDistance : OrbitItemTestBase
    {
        [Fact]
        public void CanBeChangedToPossitiveInterger()
        {
            const int goalValue = 5;

            sut.OrbitingDistance = goalValue;

            Assert.Equal(goalValue, sut.OrbitingDistance);
        }

        [Fact]
        public void CanNotBeChangedToNegativeInterger()
        {
            int origionalValue = sut.OrbitingDistance;
            const int goalValue = -5;

            sut.OrbitingDistance = goalValue;

            Assert.Equal(origionalValue, sut.OrbitingDistance);
        }

        [Fact]
        public void CanNotBeChangedToZero()
        {
            int origionalValue = sut.OrbitingDistance;
            const int goalValue = 0;

            sut.OrbitingDistance = goalValue;

            Assert.Equal(origionalValue, sut.OrbitingDistance);
        }

        [Fact]
        public void CanNotBeChangedFromZeroWhenOrbitingIdZero()
        {
            const int goalValue = 5;

            sut.OrbitingId = 0;
            sut.OrbitingDistance = goalValue;

            Assert.Equal(0, sut.OrbitingDistance);
        }
    }
}
