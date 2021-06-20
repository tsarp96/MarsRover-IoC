﻿using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTest_NUnit
{
    public class InputServiceTest
    {

        [Test]
        [TestCase("x g")]
        [TestCase("55")]
        [TestCase("5 5 5")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("-5 -5")]
        [TestCase("& %")]
        [TestCase("0 0")] // plateau should not be a dot.
        public void ProcessPlateauInput_InputIsNotValid_ShouldReturnNull(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.ProcessPlateauInput(input);
            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("5 5")]
        public void ProcessPlateauInput_InputIsOk_ShouldReturnPlateau(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.ProcessPlateauInput(input);
            //Assert
            Assert.That(result.GetType(), Is.EqualTo(typeof(Plateau)));
            Assert.That(result.HorizontalUpperRightBoundry, Is.EqualTo(5));
            Assert.That(result.VerticalUpperRightBoundry, Is.EqualTo(5));
            Assert.That(result.HorizontalLoweLeftBoundry, Is.EqualTo(0));
            Assert.That(result.VerticalLowerLeftBoundry, Is.EqualTo(0));

        }

        [Test]
        [TestCase("1 2 G")]
        [TestCase("-1 -5 N")]
        [TestCase("12N")]
        [TestCase("  1 2 2 N")]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase("& % /")]
        public void ProcessRoverCoordinatesInput_InputIsNotValid_ShouldReturnNull(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.ProcessRoverCoordinatesInput(input);
            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("1 2 N")]
        [TestCase("1 2 n")]
        public void ProcessRoverCoordinatesInput_InputIsOk_ShouldReturnProperPosition(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.ProcessRoverCoordinatesInput(input);
            //Assert
            Assert.That(result.GetType(), Is.EqualTo(typeof(Position)));
            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Direction, Is.EqualTo((int)Compass.N));
        }


        [Test]
        [TestCase("LMRX")]
        [TestCase("L M R")]
        [TestCase(" ")]
        [TestCase("")]
        public void IsRoversExplorationPathInputValid_InputIsNotValid_ShouldReturnNull(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.IsRoversExplorationPathInputValid(input);
            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("LMR")]
        [TestCase("lmr")]
        [TestCase(" lmr ")]
        [TestCase("m")]
        public void IsRoversExplorationPathInputValid_InputIsOk_ShouldReturnProperly(string input)
        {
            //Arrange
            IInputService SUT = new InputService();
            //Act
            var result = SUT.IsRoversExplorationPathInputValid(input);
            //Assert
            Assert.That(result, Is.EqualTo(input.Trim().ToUpper()));
        }

    }
}