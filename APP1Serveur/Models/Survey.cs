using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
