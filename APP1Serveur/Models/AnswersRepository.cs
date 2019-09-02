using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class AnswersRepository : IAnswersRepository
    {
        private List<Answers> answers = new List<Answers>();
        private int _nextId = 1;

        public AnswersRepository()
        {
            Add(new Answers { PersonId = 1, SurveyId = 1, responses = new List<string>{ "a", "b" } });
        }

        public Answers Add(Answers item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            answers.Add(item);
            return item;
        }

        public IEnumerable<Answers> GetAll()
        {
            return answers;
        }

        public Answers Get(int id)
        {
            return answers.Find(p => p.Id == id);
        }

        public void Remove(int id)
        {
            answers.RemoveAll(p => p.Id == id);
        }

        public bool Update(Answers item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = answers.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            answers.RemoveAt(index);
            answers.Add(item);
            return true;
        }
    }
}
