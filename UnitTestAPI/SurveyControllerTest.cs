using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP1Serveur.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestAPI
{
    [TestClass]
    public class SurveyControllerTest
    {
        SurveyController _controller;

        public SurveyControllerTest()
        {
            _controller = new SurveyController();
        }
        [TestMethod]
        public void TestDetailsViewData()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
