using NUnit.Framework;
using MarsRoverTunaSarp;
using System;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTest_NUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateRover_PositionIsNull_ShouldThrowNullArgumentException()
        {
            //Arrange
            Position position = null;
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Rover(position));
        }

        [Test]
        public void TurnRight_InitialPositionProperlySet_ShouldUpdatePositionCorrectly()
        {
            //Arrange
            Rover sut = new Rover(new Position(1, 2, (int)Compass.N));
            // Act 
            sut.TurnRight();
            //Assert
            Assert.That(sut.Position.Direction, Is.EqualTo((int)Compass.E));
        }

        [Test]
        public void TurnLeft_InitialPositionProperlySet_ShouldUpdatePositionCorrectly()
        {
            //Arrange
            Rover sut = new Rover(new Position(1, 2, (int)Compass.N));
            // Act 
            sut.TurnLeft();
            //Assert
            Assert.That(sut.Position.Direction, Is.EqualTo((int)Compass.W));
        }

        [Test]
        [TestCase((int)Compass.N)]
        [TestCase((int)Compass.E)]
        [TestCase((int)Compass.S)]
        [TestCase((int)Compass.W)]
        public void Move_RoverFacingDifferentDirections_ShouldUpdatePositionCorrectly(int direction)
        {
            //Arrange
            int x = 1;
            int y = 2;
            Rover sut = new Rover(new Position(x, y, direction));
            // Act 
            sut.Move();
            //Assert
            switch(direction)
            {
                case (int)Compass.N:
                    Assert.That(sut.Position.Direction, Is.EqualTo(direction));
                    Assert.That(sut.Position.X, Is.EqualTo(x));
                    Assert.That(sut.Position.Y, Is.EqualTo(y + 1));
                    break;
                case (int)Compass.W:
                    Assert.That(sut.Position.Direction, Is.EqualTo(direction));
                    Assert.That(sut.Position.X, Is.EqualTo(x - 1));
                    Assert.That(sut.Position.Y, Is.EqualTo(y));
                    break;
                case (int)Compass.S:
                    Assert.That(sut.Position.Direction, Is.EqualTo(direction));
                    Assert.That(sut.Position.X, Is.EqualTo(x));
                    Assert.That(sut.Position.Y, Is.EqualTo(y - 1));
                    break;
                case (int)Compass.E:
                    Assert.That(sut.Position.Direction, Is.EqualTo(direction));
                    Assert.That(sut.Position.X, Is.EqualTo(x + 1));
                    Assert.That(sut.Position.Y, Is.EqualTo(y));
                    break;
            }
        }

        [Test]
        public void TraceRoute_BoundryBreachDetected_ShouldThrowAnException()
        {
            //Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(0, 0, (int)Compass.S));
            string route = "MLM";
            ExplorationService sut = new ExplorationService(rover, plateau, route);
            //Act & Assert
            Assert.Throws<Exception>(() => sut.TraceRoute());
            
        }
    }
}