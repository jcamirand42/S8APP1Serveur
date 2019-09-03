using System;
using System.Collections.Generic;
using System.Text;
using APP1Serveur.Controllers;
using APP1Serveur.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestAPI
{
    public class LoginControllerTest
    {
        LoginController _controller;
        public LoginControllerTest()
        {
            _controller = new LoginController();
        }
        [Fact]
        public void GetAllLogin()
        {
            var result = _controller.GetAllLogin();

            Assert.IsType<List<Login>>(result);
        }
        [Fact]
        public void GetId()
        {
            var result = _controller.Get(1);

            Assert.IsType<Login>(result);
        }
        [Fact]
        public void PostOkResult()
        {
            Login item = _controller.Get(1);
            var result = _controller.Post(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PostNotFound()
        {
            Login item = new Login();
            var result = _controller.Post(item);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void PostInvalidPassword()
        {
            Login item = new Login();
            item.Username = "admin";
            item.Password = "admin1";
            var result = _controller.Post(item);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void PostNullLogin()
        {
            var result = _controller.Post(null);

            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void PutOkResult()
        {
            Login item = _controller.Get(1);
            Assert.Equal("admin", item.Username);
            item.Username = "bob";
            var result = _controller.Put(item);
            item = _controller.Get(1);
            Assert.Equal("bob", item.Username);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void PutNullLogin()
        {
            var result = _controller.Put(null);

            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void PutNotFound()
        {
            Login item = new Login();
            item.Id = 3;
            var result = _controller.Put(item);

            Assert.IsType<BadRequestResult>(result);
        }

    }
}
