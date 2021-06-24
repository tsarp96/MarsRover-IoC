using MarsRoverTunaSarp;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Services;
using NUnit.Framework;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Interfaces;

namespace MarsRoverTest_NUnit
{
    public class ExplorationServiceTest
    {
        private readonly IExplorationService _sut;
        
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            ResetSut();
        }
        
        [Test]
        public void TraceRoute_BoundaryBreachDetected_ShouldThrowAnException()
        {
            //Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(0, 0, (int)Compass.S));
            const string route = "MLM";
            _sut.UpdateRover(rover);
            _sut.UpdatePlateau(plateau);
            _sut.UpdateRoute(route);
            
            //Act & Assert
            Assert.That(_sut.TraceRoute(), Is.EqualTo(ExplorationResult.BoundaryBreachDetected));

        }

        [Test]
        public void TraceRoute_ParameterIsNormal_RoverShouldBeReallocatedCorrectly()
        {
            //Arrange
            var plateau = new Plateau(5, 5);
            var rover = new Rover(new Position(1, 2, (int)Compass.N));
            const  string route = "LMLMLMLMMR";
            _sut.UpdateRover(rover);
            _sut.UpdatePlateau(plateau);
            _sut.UpdateRoute(route);
            //Act
            _sut.TraceRoute();
            //Assert
            Assert.That(rover.Position.X, Is.EqualTo(1));
            Assert.That(rover.Position.Y, Is.EqualTo(3));
            Assert.That(rover.Position.Direction, Is.EqualTo((int)Compass.E));

        }
        private void ResetSut()
        {
            _sut.UpdateRover(null);
            _sut.UpdatePlateau(null);
            _sut.UpdateRoute(null);
        }

    }
}
