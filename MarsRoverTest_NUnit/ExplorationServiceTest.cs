using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRoverTest_NUnit
{
    public class ExplorationServiceTest
    {
        IExplorationService sut = ExplorationService.Instance;


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            sut.setRover(null);
            sut.setPlateau(null);
            sut.setRoute(null);
        }

        [Test]
        public void TraceRoute_BoundryBreachDetected_ShouldThrowAnException()
        {
            //Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(0, 0, (int)Compass.S));
            string route = "MLM";
            sut.setRover(rover);
            sut.setPlateau(plateau);
            sut.setRoute(route);
            
            //Act & Assert
            Assert.Throws<Exception>(() => sut.TraceRoute());

        }

        [Test]
        public void TraceRoute_ParameterIsNormal_RoverShouldBeReallocatedCorrectly()
        {
            //Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2, (int)Compass.N));
            string route = "LMLMLMLMMR";
            sut.setRover(rover);
            sut.setPlateau(plateau);
            sut.setRoute(route);
            //Act
            sut.TraceRoute();
            //Assert
            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
            Assert.That(rover.Position.Direction, Is.EqualTo((int)Compass.E));

        }

    }
}
