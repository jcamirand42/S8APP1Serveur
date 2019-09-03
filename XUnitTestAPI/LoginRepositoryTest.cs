using System;
using System.Collections.Generic;
using System.Text;
using APP1Serveur.Models;
using Xunit;

namespace XUnitTestAPI
{
    public class LoginRepositoryTest
    {
        LoginRepository _repo;
        public LoginRepositoryTest()
        {
            _repo = new LoginRepository();
        }
        [Fact]
        public void CheckIdentity()
        {
            
        }
    }
}
