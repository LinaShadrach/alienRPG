using basicRPG.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace basicRPG.Tests.ControllerTests
{
    public class PlayersControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index()
        {
            PlayersController controller = new PlayersController();
            var result = controller.Edit();
            Assert.IsType<ViewResult>(result);
        }
    }
}
