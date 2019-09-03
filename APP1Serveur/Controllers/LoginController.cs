using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            //if (item == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public Login Post([FromBody]Login item)
        {
            return repository.Add(item);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]Login item)
        {
            repository.Update(item);
        }
    }
}
