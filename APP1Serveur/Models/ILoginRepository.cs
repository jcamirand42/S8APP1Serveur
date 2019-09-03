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
        Login GetUserInfo(Login userLog);
        void Add(Login item);
        bool CheckIdentity(Login item);
        bool Update(Login item);
    }
}
