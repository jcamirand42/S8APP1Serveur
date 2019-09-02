using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APP1Serveur.Models;
using System.Net.Http;
using System.Net;

namespace APP1Serveur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        static readonly IAnswersRepository repository = new AnswersRepository();

        public ActionResult<IEnumerable<Answers>> Get()
        {
            return repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Answers> Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Answers item)
        {
            repository.Add(item);
        }
    }
}