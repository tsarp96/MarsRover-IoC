using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MarsRoverTest_NUnit
{
    public class ExplorationServiceTest
    {
        static List<List<Object>> explorationServiceParametersWithNulls = new List<List<Object>>()
        {
            new List<Object>() { new Rover(new Position(1, 2, (int)Compass.N)), new Plateau(5, 5), null },
            new List<Object>() { null, new Plateau(5, 5), "LMRL" },
            new List<Object>() { new Rover(new Position(1, 2, (int)Compass.N)), null, "LMR" },
        };

      
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

        [Test]
        [TestCaseSource("explorationServiceParametersWithNulls")]
        public void CreateExplorationService_SendNullParameters_ShouldThrowAnException(List<Object> parameters)
        {
            Assert.Throws<ArgumentNullException>(() => new ExplorationService((Rover)parameters[0], (Plateau)parameters[1], (string)parameters[2]));
        }

        [Test]
        public void TraceRoute_ParameterIsNormal_RoverShouldBeReallocatedCorrectly()
        {
            //Arrange
            Plateau plateau = new Plateau(5, 5);
            Rover rover = new Rover(new Position(1, 2, (int)Compass.N));
            string route = "LMLMLMLMMR";
            ExplorationService sut = new ExplorationService(rover, plateau, route);
            //Act
            sut.TraceRoute();
            //Assert
            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
            Assert.That(rover.Position.Direction, Is.EqualTo((int)Compass.E));

        }

    }
}
