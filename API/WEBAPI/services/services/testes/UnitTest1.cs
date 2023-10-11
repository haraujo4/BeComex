using System.Collections.Generic;
using APP.Controllers;
using BLL.DTO;
using BLL.Interface.Services;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace SeuProjetoDeTesteNamespace
{
    public class RoboControllerTests
    {
        [Fact]
        public void GetRoboPosition_ReturnsListOfRobo()
        {
            // Arrange
            var mockService = new Mock<IRoboActionServices>();
            mockService.Setup(service => service.GetRoboAction()).Returns(new List<Robo>
            {
                new Robo { 
                    Id = 1,
                    Body_Name = "BRACO",
                    Body_Item_Name = "COTOVELO",
                    Side = "DIREITO",
                    Action_Order = 1,
                    Action = "REPOUSO" 
                },
                new Robo { 
                    Id = 2, 
                    Body_Name = "BRACO", 
                    Body_Item_Name = "COTOVELO", 
                    Side = "DIREITO", 
                    Action_Order = 2, 
                    Action = "LEVEMENTE CONTRAIDO" 
                }
            });

            var controller = new RoboController(mockService.Object);

            // Act
            var result = controller.GetRoboPosition();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Robo>>(okResult.Value);
            Assert.NotEmpty(model);
        }

        [Fact]
        public async Task SendAction_ReturnsTrue()
        {
            // Arrange
            var mockService = new Mock<IRoboActionServices>();
            mockService.Setup(service => service.SendAction(It.IsAny<RoboDTO>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(true);

            var controller = new RoboController(mockService.Object);

            // Act
            var result = await controller.SendAction(new RoboDTO {
                Body_Name = "BRACO",
                Body_Item_Name = "COTOVELO",
                Side = "DIREITO",
                Action_Order = 2,
                Action = "LEVEMENTE CONTRAIDO"
            }, 1, "REPOUSO");

            // Assert
            Assert.True(result);
        }
    }
}
