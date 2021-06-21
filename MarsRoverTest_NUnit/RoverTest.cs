using NUnit.Framework;
using System;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;

namespace MarsRoverTest_NUnit
{
    public class RoverTest
    {
        [Test]
        public void CreateRover_PositionIsNull_ShouldThrowNullArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Rover(null));
        }

        [Test]
        public void TurnRight_InitialPositionProperlySet_ShouldUpdatePositionCorrectly()
        {
            //Arrange
            var sut = new Rover(new Position(1, 2, (int)Compass.N));
            // Act 
            sut.TurnRight();
            //Assert
            Assert.That(sut.Position.Direction, Is.EqualTo((int)Compass.E));
        }

        [Test]
        public void TurnLeft_InitialPositionProperlySet_ShouldUpdatePositionCorrectly()
        {
            //Arrange
            var sut = new Rover(new Position(1, 2, (int)Compass.N));
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
            const int x = 1;
            const int y = 2;
            var sut = new Rover(new Position(x, y, direction));
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
    }
}