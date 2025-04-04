﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class WriteAngleToFile : TideCalculatorTestBase
    {
        [Fact]
        public void ReturnsFalse_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
        }

        [Fact]
        public void InvokesIWriterCanWrite()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.CanWriteTo(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterCanWriteWithSetPath()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.CanWriteTo(path));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterCanWriteToReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(false);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenIWriterCanWriteToReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(false);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
        }

        [Fact]
        public void InvokesIWriterIsWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.IsWriting());
        }

        [Fact]
        public void ReturnsFalse_IWriterIsWritingReturnsTrue()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.IsWriting()).Returns(true);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_IWriterIsWritingReturnsTrue()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.IsWriting()).Returns(true);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIdOfOrbitItem()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>()));
        }
        

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIdOfOrbitItemWithGivenItems()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.GetIdOf(star));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteOne));
            mockItemsRepository.Verify(m => m.GetIdOf(sataliteTwo));
        }

        [Fact]
        public void Returnsfalse_WhenItemNotInRange()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value:null);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenItemNotInRange()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            mockItemsRepository.Setup(m => m.GetIdOf(It.IsAny<Entities.OrbitItem>())).Returns(value: null);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void Returnsfalse_WhenItemWithSameId()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteOne.Id);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenItemWithSameId()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteOne.Id);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetInt()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetIntExpectedAmountsOfTimes()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Exactly(3));
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetWithReturnedIds()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockItemsRepository.Verify(m => m.Get(star.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteOne.Id));
            mockItemsRepository.Verify(m => m.Get(sataliteTwo.Id));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterWriteReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void InvokesIWriterStartWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterStartWritingWithSetPath()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path));
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterStartWriting_ReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            sut.SetWritePath(path);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(false);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void CallsIWriterStopWriting()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.StopWriting());
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterStopWritingReturnsFalse()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsTrue_WhenAllCorrect()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.True(result);
        }

        [Fact]
        public void InvokesIWriterWrite()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterWriteCorrectAmountOfTimes()
        {
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(4));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_Start()
        {
            string expectedOne = "0" + Services.TideCalculator.FieldSepertor;
            string expectedTwo = "1" + Services.TideCalculator.FieldSepertor;
            string expectedThree = "2" + Services.TideCalculator.FieldSepertor;
            string expectedFour = "3" + Services.TideCalculator.FieldSepertor;
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            List<string> responces = new();
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.StartsWith(expectedOne, responces[0]);
            Assert.StartsWith(expectedTwo, responces[1]);
            Assert.StartsWith(expectedThree, responces[2]);
            Assert.StartsWith(expectedFour, responces[3]);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_StartWithLeadingZeros()
        {
            string expectedOne = "00" + Services.TideCalculator.FieldSepertor;
            string expectedTwo = "05" + Services.TideCalculator.FieldSepertor;
            string expectedThree = "10" + Services.TideCalculator.FieldSepertor;
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            List<string> responces = new();
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 10, 5);

            Assert.StartsWith(expectedOne, responces[0]);
            Assert.StartsWith(expectedTwo, responces[1]);
            Assert.StartsWith(expectedThree, responces[2]);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_End()
        {
            string expected = Services.TideCalculator.LineSeperator;
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            List<string> responces = new();
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.EndsWith(expected, responces[0]);
            Assert.EndsWith(expected, responces[1]);
            Assert.EndsWith(expected, responces[2]);
            Assert.EndsWith(expected, responces[3]);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_CorrectNumberOfSeperators()
        {
            string seperator = Services.TideCalculator.FieldSepertor;
            int expected = 1;
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            List<string> responces = new();
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            for (int i = 0; i < responces.Count; i++)
            {
                int numberOfSeperator = (responces[i].Length - responces[i].Replace(seperator, "").Length) / seperator.Length;
                Assert.Equal(expected, numberOfSeperator);
            }
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_Value()
        {
            double expectedOne = Math.Acos(1);
            double expectedTwo = Math.Acos(0);
            double expectedThree = Math.Acos(-1);
            double expectedFour = -Math.Acos(0);
            var star = SystemOneStar;
            var sataliteOne = SystemOneSataliteOne;
            var sataliteTwo = SystemOneSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetIdOf(star)).Returns(star.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteOne)).Returns(sataliteOne.Id);
            mockItemsRepository.Setup(m => m.GetIdOf(sataliteTwo)).Returns(sataliteTwo.Id);
            mockItemsRepository.Setup(m => m.Get(star.Id)).Returns(star);
            mockItemsRepository.Setup(m => m.Get(sataliteOne.Id)).Returns(sataliteOne);
            mockItemsRepository.Setup(m => m.Get(sataliteTwo.Id)).Returns(sataliteTwo);
            List<string> responces = new();
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteAngleToFile(star, sataliteTwo, sataliteOne, 0, 3, 1);

            Assert.Equal(expectedOne, double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
            Assert.Equal(expectedTwo, double.Parse(responces[1].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
            Assert.Equal(expectedThree, double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
            Assert.Equal(expectedFour, double.Parse(responces[3].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
        }
    }
}
