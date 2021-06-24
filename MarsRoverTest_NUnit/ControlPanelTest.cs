using MarsRoverTunaSarp.Interfaces;
using Moq;
using NUnit.Framework;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;
using System;

namespace MarsRoverTest_NUnit
{
    public class ControlPanelTest
    {

        private IControlPanel _sut;

        [Test]
        public void TestCaseA_InputIsOk_ShouldActNormally()
        {
            var retriever = new Mock<IRetriever>();
            var explorationService = new Mock<IExplorationService>();
            var inputService = new Mock<IInputService>();

            inputService.Setup(i => i.ProcessPlateauInput("5 5")).Returns(new Plateau(5, 5));
            inputService.Setup(i => i.ProcessRoverPositionInput("1 2 N")).Returns(new Position(1, 2, (int)Enum.Parse(typeof(Compass), "N")));
            inputService.Setup(i => i.IsRoversExplorationPathInputValid("LMLMLMLMM")).Returns("LMLMLMLMM");

            retriever.Setup(r => r.GetPlateauInput()).Returns("5 5");
            retriever.Setup(r => r.GetRoverPositionInput()).Returns("1 2 N");
            retriever.Setup(r => r.GetRouteInput()).Returns("LMLMLMLMM");

            explorationService.Setup(e => e.TraceRoute()).Returns(ExplorationResult.Success);


            _sut = new MarsRoverControlPanel(retriever.Object, explorationService.Object, inputService.Object, 1);
            
            //Act
            var result = _sut.Start();
            //Assert
            Assert.That(result, Is.EqualTo(PanelResult.Success));
        }

    }
}
