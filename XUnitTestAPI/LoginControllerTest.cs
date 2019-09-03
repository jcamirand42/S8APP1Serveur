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
        public void Test1()
        {
            var result = _controller.GetAllLogin();

            Assert.IsType<List<Login>>(result);
        }
        [Fact]
        public void Test2()
        {
            var result = _controller.Get(1);

            Assert.IsType<Login>(result);
        }
        [Fact]
        public void Test3()
        {
            var result = _controller.Post(new Login());

            Assert.IsType<Login>(result);
        }
        [Fact]
        public void Test4()
        {
            Login item = _controller.Get(1);
            Assert.Equal("admin", item.Username);
            item.Username = "bob";
            _controller.Put(item);
            item = _controller.Get(1);
            Assert.Equal("bob", item.Username);
        }

    }
}
