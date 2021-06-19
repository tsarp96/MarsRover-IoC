using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTest_NUnit
{
    public class ExplorationServiceTest
    {
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
