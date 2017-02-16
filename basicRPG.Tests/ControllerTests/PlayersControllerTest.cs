using basicRPG.Controllers;
using basicRPG.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public void Get_ViewResult_Edit()
        {
            PlayersController controller = new PlayersController();
            var result = controller.Edit(7);

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Get_ModelPlayer_Edit()
        {
            ViewResult editView = new PlayersController().Edit(7) as ViewResult;
            var result = editView.ViewData.Model;
            Assert.IsType<Player>(result);
        }
    }
}
