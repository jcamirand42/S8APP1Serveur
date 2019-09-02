using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class QuestionRepository : IQuestionRepository
    {
        private List<Question> questions = new List<Question>();
        private int _nextId = 1;

        public QuestionRepository()
        {
            string str1 = "À quelle tranche d'âge appartenez-vous?";
            string str2 = "Êtes-vous une femme ou un homme?";
            string str3 = "Combien de tasses de café buvez-vous chaque jour?";

            Add(new Question { SurveyId = 1, Statement = str1, Choices = new Dictionary<string, string> { ["a"] = "1", ["b"] = "2" } });
            Add(new Question { SurveyId = 1, Statement = str2, Choices = new Dictionary<string, string> { ["a"] = "11", ["b"] = "22" } });
            Add(new Question { SurveyId = 2, Statement = str3, Choices = new Dictionary<string, string> { ["a"] = "111", ["b"] = "222" } });
        }

        public Question Add(Question item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            questions.Add(item);
            return item;
        }

        public IEnumerable<Question> GetAll()
        {
            return questions;
        }

        public IEnumerable<Question> GetSurveyQuestions(int id)
        {
            return questions.FindAll(p => p.SurveyId == id);
        }

        public Question Get(int id)
        {
            return questions.Find(p => p.Id == id);
        }

        public void Remove(int id)
        {
            questions.RemoveAll(p => p.Id == id);
        }

        public bool Update(Question item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = questions.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            questions.RemoveAt(index);
            questions.Add(item);
            return true;
        }

    }
}
