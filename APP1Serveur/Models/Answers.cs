using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SurveyId { get; set; }
        public List<string> responses { get; set; }
    }
}
