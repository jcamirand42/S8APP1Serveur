using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    public class SurveyRepository : ISurveyRepository
    {
        private List<Survey> surveys = new List<Survey>();
        private int _nextId = 1;

        public SurveyRepository()
        {
             
            Add(new Survey { Name = "Sondage 1", Questions = (new QuestionRepository()).GetSurveyQuestions(1).ToList() });
            Add(new Survey { Name = "Sondage 2", Questions = (new QuestionRepository()).GetSurveyQuestions(2).ToList() });
        }

        public Survey Add(Survey item)
        {
            item.Id = _nextId++;
            surveys.Add(item);
            return item;
        }

        public IEnumerable<Survey> GetAll()
        {
            return surveys;
        }

        public Survey Get(int id)
        {
            return surveys.Find(p => p.Id == id);
        }
    }
}
