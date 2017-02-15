using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basicRPG.Models;
using Xunit;

namespace basicRPG.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Player_GetName_TestName()
        {
            //Arrange
            Player player = new Player("Test Name");

            //Act
            string name = player.Name;

            //Assert
            Assert.Equal("Test Name", name);
        }
    }
}
