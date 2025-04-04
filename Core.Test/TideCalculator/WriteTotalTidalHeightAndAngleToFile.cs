﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test.TideCalculator
{
    public class WriteTotalTidalHeightAndAngleToFile : TideCalculatorTestBase
    {
        new readonly double tolerance = 0.0001;

        [Fact]
        public void ReturnsFalse_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenSetWritePathNotSet()
        {
            var star = SystemOneStar;
            var sataliteTwo = SystemOneSataliteTwo;

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
        }

        [Fact]
        public void InvokesIOrbitItemsRepositoryGetAll()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);

            sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockItemsRepository.Verify(m => m.GetAll());
        }

        [Fact]
        public void Returnsfalse_WhenIOrbitItemsRepositoryGetAllReturnsNull()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: null);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenIOrbitItemsRepositoryGetAllReturnsNull()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: null);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
        }

        [Fact]
        public void Returnsfalse_WhenIOrbitItemsRepositoryGetAllReturnsEmpty()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: []);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void DoesNotInvokeIWriterStartWriting_WhenIOrbitItemsRepositoryGetAllReturnsEmpty()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: []);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.StartWriting(path), Times.Never());
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
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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
            mockWriter.Setup(m => m.StartWriting(path)).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterWriteReturnsFalse()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void CallsIWriterStopWriting()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.StopWriting());
        }

        [Fact]
        public void ReturnsFalse_WhenIWriterStopWritingReturnsFalse()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(false);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.False(result);
        }

        [Fact]
        public void ReturnsTrue_WhenAllCorrect()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.True(result);
        }

        [Fact]
        public void InvokesIWriterWrite()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()));
        }

        [Fact]
        public void InvokesIWriterWriteCorrectAmountOfTimes()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            mockWriter.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(4));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_Start()
        {
            string expectedOne = "0" + Services.TideCalculator.FieldSepertor;
            string expectedTwo = "1" + Services.TideCalculator.FieldSepertor;
            string expectedThree = "2" + Services.TideCalculator.FieldSepertor;
            string expectedFour = "3" + Services.TideCalculator.FieldSepertor;
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

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
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 10, 5);

            Assert.StartsWith(expectedOne, responces[0]);
            Assert.StartsWith(expectedTwo, responces[1]);
            Assert.StartsWith(expectedThree, responces[2]);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_End()
        {
            string expected = Services.TideCalculator.LineSeperator;
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.EndsWith(expected, responces[0]);
            Assert.EndsWith(expected, responces[1]);
            Assert.EndsWith(expected, responces[2]);
            Assert.EndsWith(expected, responces[3]);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_CorrectNumberOfSeperators()
        {
            string seperator = Services.TideCalculator.FieldSepertor;
            int expected = 4;
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            for (int i = 0; i < responces.Count; i++)
            {
                int numberOfSeperator = (responces[i].Length - responces[i].Replace(seperator, "").Length) / seperator.Length;
                Assert.Equal(expected, numberOfSeperator);
            }
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueOneLessWhenFurtherAway_WhenInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.True(double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[1]) > double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[1]));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueOne_WhenInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            double expectedOne = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance)) * 3 / 5;
            double expectedTwo = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance)) * 3 / 5;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.Equal(expectedOne, double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
            Assert.Equal(expectedTwo, double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[1]), tolerance);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueTwoEqualToThree_WhenInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            double expectedOne = -(GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance)) * -2 / 3;
            double expectedTwo = -(GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance)) * -2 / 3;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.Equal(double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[3]), double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[2]), tolerance);
            Assert.Equal(double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[3]), double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[2]), tolerance);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueTwo_WhenInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            double expectedOne = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance)) / -3;
            double expectedTwo = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance)) / -3;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.Equal(expectedOne, double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[2]), tolerance);
            Assert.Equal(expectedTwo, double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[2]), tolerance);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueTwoLessThenOne_WhenNotInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.True(double.Parse(responces[1].Split(Services.TideCalculator.FieldSepertor)[2]) < double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[1]));
            Assert.True(double.Parse(responces[3].Split(Services.TideCalculator.FieldSepertor)[2]) < double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[1]));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueTwoMoreThenThree_WhenNotInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.True(double.Parse(responces[1].Split(Services.TideCalculator.FieldSepertor)[2]) > double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[3]));
            Assert.True(double.Parse(responces[3].Split(Services.TideCalculator.FieldSepertor)[2]) > double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[3]));
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueThree()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            double expectedOne = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance - sataliteOne.OrbitingDistance)) / -3;
            double expectedTwo = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, Math.Pow(Math.Pow(sataliteTwo.OrbitingDistance, 2) + Math.Pow(sataliteOne.OrbitingDistance, 2), 0.5))) / -3;
            double expectedThree = (GetTidalHeight(star.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance) + GetTidalHeight(sataliteOne.Mass, sataliteTwo.Mass, sataliteTwo.Radius, sataliteTwo.OrbitingDistance + sataliteOne.OrbitingDistance)) / -3;
            double expectedFour = expectedTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.Equal(expectedOne, double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[3]), tolerance);
            Assert.Equal(expectedTwo, double.Parse(responces[1].Split(Services.TideCalculator.FieldSepertor)[3]), tolerance);
            Assert.Equal(expectedThree, double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[3]), tolerance);
            Assert.Equal(expectedFour, double.Parse(responces[3].Split(Services.TideCalculator.FieldSepertor)[3]), tolerance);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueFourIsZero_WhenInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            double expected = 0;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.Equal(expected, double.Parse(responces[0].Split(Services.TideCalculator.FieldSepertor)[4]), tolerance);
            Assert.Equal(expected, double.Parse(responces[2].Split(Services.TideCalculator.FieldSepertor)[4]), tolerance);
        }

        [Fact]
        public void InvokesIWriterWriteWithCorrectStrings_ValueFourBiggerOrSmallerThenZero_WhenNotInLine()
        {
            var star = SystemTwoStar;
            var sataliteOne = SystemTwoSataliteOne;
            var sataliteTwo = SystemTwoSataliteTwo;
            mockWriter.Setup(m => m.CanWriteTo(path)).Returns(true);
            mockWriter.Setup(m => m.IsWriting()).Returns(false);
            mockWriter.Setup(m => m.StartWriting(path)).Returns(true);
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true);
            mockWriter.Setup(m => m.StopWriting()).Returns(true);
            sut.SetWritePath(path);
            mockItemsRepository.Setup(m => m.GetAll()).Returns(value: [star, sataliteOne, sataliteTwo]);
            List<string> responces = [];
            mockWriter.Setup(m => m.Write(It.IsAny<string>())).Returns(true).Callback<string>(c => responces.Add(c));

            var result = sut.WriteTotalTidalHeightAndAngleToFile(sataliteTwo, star, 0, 3, 1);

            Assert.True(double.Parse(responces[1].Split(Services.TideCalculator.FieldSepertor)[4]) > 0 + tolerance);
            Assert.True(double.Parse(responces[3].Split(Services.TideCalculator.FieldSepertor)[4]) < 0 - tolerance);
        }
    }
}
