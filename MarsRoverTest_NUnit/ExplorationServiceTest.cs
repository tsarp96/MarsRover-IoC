using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRoverTest_NUnit
{
    public class ExplorationServiceTest
    {
        ExplorationService SUT = ExplorationService.Instance;


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            SUT.Rover = null;
            SUT.Plateau = null;
            SUT.Route = null;
        }

        [Test]
        public void TraceRoute_BoundryBreachDetected_ShouldThrowAnException()
        {
            //Arrange
            Plateau Plateau = new Plateau(5, 5);
            Rover Rover = new Rover(new Position(0, 0, (int)Compass.S));
            string Route = "MLM";
            SUT.Rover = Rover;
            SUT.Plateau = Plateau;
            SUT.Route = Route;
            
            //Act & Assert
            Assert.That(SUT.TraceRoute(), Is.EqualTo(ExplorationResult.BoundryBreachDetected));

        }

        [Test]
        public void TraceRoute_ParameterIsNormal_RoverShouldBeReallocatedCorrectly()
        {
            //Arrange
            Plateau Plateau = new Plateau(5, 5);
            Rover Rover = new Rover(new Position(1, 2, (int)Compass.N));
            string Route = "LMLMLMLMMR";
            SUT.Rover = Rover;
            SUT.Plateau = Plateau;
            SUT.Route = Route;
            //Act
            SUT.TraceRoute();
            //Assert
            Assert.That(Rover.Position.X, Is.EqualTo(1));
            Assert.That(Rover.Position.Y, Is.EqualTo(3));
            Assert.That(Rover.Position.Direction, Is.EqualTo((int)Compass.E));

        }

    }
}
