using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    interface ISurveyRepository
    {
        IEnumerable<Survey> GetAll();
        Survey Get(int id);
        Survey Add(Survey item);
        void Remove(int id);
        bool Update(Survey item);
    }
}

