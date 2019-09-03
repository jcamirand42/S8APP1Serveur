using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class LoginRepository : ILoginRepository
    {
        private List<Login> logins = new List<Login>();
        private int _nextId = 1;

        public LoginRepository()
        {
            Add(new Login { Username = "admin", Password = "admin", Responses = new List<Answers>() });
            Add(new Login { Username = "mmpepin", Password = "mmpepin", Responses = new List<Answers>() });
        }

        public IEnumerable<Login> GetAll()
        {
            return logins;
        }

        public Login Get(int id)
        {
            return logins.Find(p => p.Id == id);
        }

        public Login GetUserInfo(Login userLog)
        {
            Login log = logins.Find(item => (item.Username == userLog.Username) && (item.Password == userLog.Password));
            return log;
        }

        public void Add(Login logInfo)
        {        
            logInfo.Id = _nextId++;
            logins.Add(logInfo);
        }

        public bool CheckIdentity(Login logInfo)
        {
            if (logInfo == null)
            {
                throw new ArgumentNullException("logInfo");
            }

            int indexUsername = logins.FindIndex(item => item.Username == logInfo.Username);
            int indexPassword = logins.FindIndex(item => item.Password == logInfo.Password);

            if (indexUsername < 0)
            {
                return false;
            }

            else if (indexUsername == indexPassword)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }

        public bool Update(Login item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = logins.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            logins.RemoveAt(index);
            logins.Add(item);
            return true;
        }
    }
}
