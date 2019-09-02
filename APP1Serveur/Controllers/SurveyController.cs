using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APP1Serveur.Models;

namespace APP1Serveur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        static readonly ISurveyRepository repository = new SurveyRepository();

        public ActionResult<IEnumerable<Survey>> Get()
        {
            return repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Survey> Get(int id)
        {
            return repository.Get(id);
        }
    }
}