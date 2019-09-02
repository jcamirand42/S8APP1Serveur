using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


using APP1Serveur.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP1Serveur.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class LoginController : Controller
    {
        static readonly ILoginRepository repository = new LoginRepository();


        // GET: api/<controller>
        [HttpGet]
        //[Authorize(Policy = "ApiKeyPolicy")]
        public IEnumerable<Login> GetAllLogin()
        {
            return repository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Login Get(int id)
        {
            Login item = repository.Get(id);
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Login item)
        {
            bool isValid = repository.CheckIdentity(item);
            if (isValid)
            {
                Login logInfo = repository.GetUserInfo(item);
                return Ok(logInfo);
            }
            return NotFound();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]Login item)
        {
            repository.Update(item);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
