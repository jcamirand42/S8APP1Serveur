﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;


using APP1Serveur.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP1Serveur.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        static readonly ILoginRepository repository = new LoginRepository();


        // GET: api/<controller>
        [HttpGet]
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
        public void Post([FromBody]Login item)
        {

            repository.Add(item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
