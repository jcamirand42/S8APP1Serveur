﻿using System;
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
    public class LoginController : Controller
    {
        static readonly ILoginRepository repository = new LoginRepository();


        // GET: api/<controller>
        [HttpGet]
        [Authorize(Policy = "ApiKeyPolicy")]
        //[Authorize(Policy = "ApiKeyPolicy")]
        public IEnumerable<Login> GetAllLogin()
        {
            return repository.GetAll();
        }

        // GET api/<controller>/5
        [Authorize(Policy = "ApiKeyPolicy")]
        [HttpGet("{id}")]
        public Login Get(int id)
        {
            Login item = repository.Get(id);
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]int item)
        {
            try
            {
                string decodeUser = "";
                string decodePass = "";

                Microsoft.Extensions.Primitives.StringValues headerValues;
                headerValues = getHeader();

                string digest = headerValues.ToString();
                string[] usercode = digest.Split(":");
                decodeUser = Base64Decode(usercode[0]);
                decodePass = Base64Decode(usercode[1]);

                Login templog = new Login();
                templog.Username = decodeUser;
                templog.Password = decodePass;

                if (repository.CheckIdentity(templog))
                {
                    Login logInfo = repository.GetUserInfo(templog);
                    return new OkObjectResult(logInfo);
                }
                return new NotFoundResult();
            }
            catch (ArgumentNullException eNull)
            {
                return new BadRequestResult();
            }
            
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize(Policy = "ApiKeyPolicy")]
        public IActionResult Put([FromBody]Login item)
        {
            try
            {
                if (repository.Update(item))
                    return new OkObjectResult(item);
                else
                    return new BadRequestObjectResult("error");
            }
            catch (ArgumentNullException)
            {
                return new BadRequestObjectResult("error");
            }
        }

        public virtual string getHeader()
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;
            Request.Headers.TryGetValue("Login", out headerValues);
            return headerValues;
        }
    }
}
