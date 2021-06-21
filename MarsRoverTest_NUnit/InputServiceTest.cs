using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;

namespace MarsRoverTest_NUnit
{
    public class InputServiceTest
    {
        //Arrange
        private  readonly IInputService _sut = InputService.Instance;

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
            Assert.Throws<ArgumentException>(() => _sut.ProcessPlateauInput(input));
        }

        [Test]
        [TestCase("5 5")]
        public void ProcessPlateauInput_InputIsOk_ShouldReturnPlateau(string input)
        {
            //Act
            var result = _sut.ProcessPlateauInput(input);
            //Assert
            Assert.That(result.GetType(), Is.EqualTo(typeof(Plateau)));
            Assert.That(result.HorizontalUpperRightBoundary, Is.EqualTo(5));
            Assert.That(result.VerticalUpperRightBoundary, Is.EqualTo(5));
            Assert.That(result.HorizontalLowerLeftBoundary, Is.EqualTo(0));
            Assert.That(result.VerticalLowerLeftBoundary, Is.EqualTo(0));
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
            Assert.Throws<ArgumentException>(() => _sut.ProcessRoverPositionInput(input));
        }

        [Test]
        [TestCase("1 2 N")]
        [TestCase("1 2 n")]
        public void ProcessRoverCoordinatesInput_InputIsOk_ShouldReturnProperPosition(string input)
        {
            //Act
            var result = _sut.ProcessRoverPositionInput(input);
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
            Assert.Throws<ArgumentException>(() => _sut.IsRoversExplorationPathInputValid(input));
        }



        [Test]
        [TestCase("LMR")]
        [TestCase("lmr")]
        [TestCase(" lmr ")]
        [TestCase("m")]
        public void IsRoversExplorationPathInputValid_InputIsOk_ShouldReturnProperly(string input)
        {
            //Act
            var result = _sut.IsRoversExplorationPathInputValid(input);
            //Assert
            Assert.That(result, Is.EqualTo(input.Trim().ToUpper()));
        }

    }
}
