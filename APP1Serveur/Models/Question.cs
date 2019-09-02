using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public String Statement { get; set; }
        public Dictionary<String, String> Choices { get; set; }
    }
}
