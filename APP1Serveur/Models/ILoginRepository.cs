using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    interface ILoginRepository
    {
        IEnumerable<Login> GetAll();
        Login Get(int id);
        Login Add(Login item);
        void Remove(int id);
        bool Update(Login item);
    }
}
