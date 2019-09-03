using System;
using System.Collections.Generic;
using System.Text;
using APP1Serveur.Controllers;
using APP1Serveur.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Moq;

namespace XUnitTestAPI
{
    public class LoginControllerTest : IDisposable
    {
        Mock<LoginController> _controller;
        public LoginControllerTest()
        {
            _controller = new Mock<LoginController>();
        }
        public void Dispose()
        {
            _controller.Object.Dispose();
        }

        [Fact]
        public void GetAllLogin()
        {
            var result = _controller.Object.GetAllLogin();

            Assert.IsType<List<Login>>(result);
        }
        [Fact]
        public void GetId()
        {
            var result = _controller.Object.Get(1);

            Assert.IsType<Login>(result);
        }
        [Fact]
        public void PostOkResult()
        {
            int entry = 0;
            string cryptUser = Base64Encode("admin");
            string cryptPass = Base64Encode("admin");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            var result2 = _controller.Object.Post(entry);

            Assert.IsType<OkObjectResult>(result2);
        }
        [Fact]
        public void PostFuzzingStringFormat()
        {
            int entry = 0;
            string cryptUser = Base64Encode("admin");
            string cryptPass = Base64Encode("null");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            var result2 = _controller.Object.Post(entry);

            // Japanese Emoticons
            Assert.IsType<NotFoundResult>(result2);

            cryptUser = Base64Encode("admin");
            cryptPass = Base64Encode("(｡◕ ∀ ◕｡)");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            result2 = _controller.Object.Post(entry);

            // Emoji
            Assert.IsType<NotFoundResult>(result2);

            cryptUser = Base64Encode("admin");
            cryptPass = Base64Encode("😍");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            result2 = _controller.Object.Post(entry);

            // Strings which contain "corrupted" text
            Assert.IsType<NotFoundResult>(result2);

            cryptUser = Base64Encode("admin");
            cryptPass = Base64Encode("Ṱ̺̺̕o͞ ̷i̲̬͇̪͙n̝̗͕v̟̜̘̦͟o̶̙̰̠kè͚̮̺̪̹̱̤ ̖t̝͕̳̣̻̪͞h̼͓̲̦̳̘̲e͇̣̰̦̬͎ ̢̼̻̱̘h͚͎͙̜̣̲ͅi̦̲̣̰̤v̻͍e̺̭̳̪̰-m̢iͅn̖̺̞̲̯̰d̵̼̟͙̩̼̘̳ ̞̥̱̳̭r̛̗̘e͙p͠r̼̞̻̭̗e̺̠̣͟s̘͇̳͍̝͉e͉̥̯̞̲͚̬͜ǹ̬͎͎̟̖͇̤t͍̬̤͓̼̭͘ͅi̪̱n͠g̴͉ ͏͉ͅc̬̟h͡a̫̻̯͘o̫̟̖͍̙̝͉s̗̦̲.̨̹͈̣");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            result2 = _controller.Object.Post(entry);

            Assert.IsType<NotFoundResult>(result2);
        }
        [Fact]
        public void PostInvalidPassword()
        {
            int entry = 0;
            string cryptUser = Base64Encode("admin");
            string cryptPass = Base64Encode("admin1");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            var result = _controller.Object.Post(entry);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void PostInvalidUsername()
        {
            int entry = 0;
            string cryptUser = Base64Encode("admin1");
            string cryptPass = Base64Encode("admin");
            _controller.Setup(x => x.getHeader()).Returns(cryptUser + ":" + cryptPass);

            var result = _controller.Object.Post(entry);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void PutOkResult()
        {
            Login item = _controller.Object.Get(1);
            Assert.Equal("admin", item.Username);
            item.Username = "bob";
            var result = _controller.Object.Put(item);
            item = _controller.Object.Get(1);
            Assert.Equal("bob", item.Username);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PutFuzzing()
        {
            Login item = _controller.Object.Get(1);
            Assert.Equal("admin", item.Username);
            item.Username = "%s%s%s%s%s";
            var result = _controller.Object.Put(item);
            item = _controller.Object.Get(1);
            Assert.Equal("%s%s%s%s%s", item.Username);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PutNullLogin()
        {
            var result = _controller.Object.Put(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void PutNotFound()
        {
            Login item = new Login();
            item.Id = 3;
            var result = _controller.Object.Put(item);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
