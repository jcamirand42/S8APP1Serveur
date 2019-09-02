using System;
using Xunit;
using APP1Serveur.Controllers;
using APP1Serveur.Models;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestAPI
{
    public class SurveyControllerTest
    {
        SurveyController _controller;
        public SurveyControllerTest()
        {
            _controller = new SurveyController();
        }
        [Fact]
        public void Test1()
        {
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<Survey>(okResult.Value);
        }
    }
}
