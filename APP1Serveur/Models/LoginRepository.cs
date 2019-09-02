using System;
using System.Collections.Generic;
using System.Linq;
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

        public Login Add(Login logInfo)
        {
            if (logInfo == null)
            {
                throw new ArgumentNullException("item");
            }

            int indexUsername = logins.FindIndex(item => item.Username == logInfo.Username);
            int indexPassword = logins.FindIndex(item => item.Password == logInfo.Password);

            Login l = logins.Find(item => (item.Username == logInfo.Username) && (item.Password == logInfo.Password));

            if (indexUsername < 0)
            {
                logInfo.Id = _nextId++;
                logInfo.Responses = new List<Answers>();
                logins.Add(logInfo);
                Console.WriteLine("Login created");
            }

            else if (indexUsername == indexPassword)
            {
                logInfo = l;
                Console.WriteLine("Login accepted");
            }

            return logInfo;
        }

        public void Remove(int id)
        {
            logins.RemoveAll(p => p.Id == id);
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
