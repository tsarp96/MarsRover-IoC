using MarsRoverTunaSarp;
using MarsRoverTunaSarp.ConsoleRetrievers;
using MarsRoverTunaSarp.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace MarsRoverTest_NUnit
{
    class ControlPanelTest
    {

        MarsRoverControlPanel SUT = MarsRoverControlPanel.Instance;

        [Test]
        public void TestCaseA_InputIsOk_ShouldActNormally()
        {
            //Arrange
            var SUT = MarsRoverControlPanel.Instance;
            SUT.RoversCount = 1; 
            var consoleMock = new Mock<IRetriever>();
            consoleMock.Setup(c => c.GetPlateauInput()).Returns("5 5");
            consoleMock.Setup(c => c.GetRoverPositionInput()).Returns("1 2 N");
            consoleMock.Setup(c => c.GetRouteInput()).Returns("LMLMLMLMM");
            SUT.ConsoleRetriever = consoleMock.Object;
            //Act
            SUT.start();
            //Assert
            Assert.That(SUT.Rovers[0].Position.ToString(), Is.EqualTo("1 3 N"));
        }
    }
}
