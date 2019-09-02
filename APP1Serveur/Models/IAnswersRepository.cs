using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    interface IAnswersRepository
    {
        IEnumerable<Answers> GetAll();
        Answers Get(int id);
        Answers Add(Answers item);
        void Remove(int id);
        bool Update(Answers item);
    }
}
