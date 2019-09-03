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
            string question1 = "À quelle tranche d'âge appartenez-vous?";
            string question2 = "Êtes-vous une femme ou un homme?";
            string question3 = "Quel journal lisez-vous à la maison?";
            string question4 = "Combien de temps accordez-vous à la lecture de votre journal quotidiennement?";
            string question5 = "À quelle tranche d'âge appartenez-vous?";
            string question6 = "Êtes-vous une femme ou un homme?";
            string question7 = "Combien de tasses de café buvez-vous chaque jour?";
            string question8 = "Combien de consommations alcoolisées buvez-vous chaque jour?";

            Add(new Question { SurveyId = 1, Statement = question1, Choices = new Dictionary<string, string> { ["a"] = "0-25 ans", ["b"] = "25-50 ans", ["c"] = "50-75 ans", ["d"] = "75 ans et plus" } });
            Add(new Question { SurveyId = 1, Statement = question2, Choices = new Dictionary<string, string> { ["a"] = "Femme", ["b"] = "Homme", ["c"] = "Je ne veux pas répondre" } });
            Add(new Question { SurveyId = 1, Statement = question3, Choices = new Dictionary<string, string> { ["a"] = "La Presse", ["b"] = "Le Journal de Montréal", ["c"] = "The Gazette", ["d"] = "Le Devoir" } });
            Add(new Question { SurveyId = 1, Statement = question4, Choices = new Dictionary<string, string> { ["a"] = "Moins de 10 minutes", ["b"] = "Entre 10 et 30 minutes", ["c"] = "Entre 30 et 60 minutes", ["d"] = "Plus de 60 minutes" } });
            Add(new Question { SurveyId = 2, Statement = question5, Choices = new Dictionary<string, string> { ["a"] = "0-25 ans", ["b"] = "25-50 ans", ["c"] = "50-75 ans", ["d"] = "75 ans et plus" } });
            Add(new Question { SurveyId = 2, Statement = question6, Choices = new Dictionary<string, string> { ["a"] = "Femme", ["b"] = "Homme", ["c"] = "Je ne veux pas répondre"} });
            Add(new Question { SurveyId = 2, Statement = question7, Choices = new Dictionary<string, string> { ["a"] = "Je ne bois pas de café", ["b"] = "Entre 1 et 5 tasses", ["c"] = "Entre 6 et 10 tasses", ["d"] = "Plus de 10 tasses" } });
            Add(new Question { SurveyId = 2, Statement = question8, Choices = new Dictionary<string, string> { ["a"] = "0", ["b"] = "1", ["c"] = "2 ou 3", ["d"] = "plus de 3" } });
        }

        public Question Add(Question item)
        {
            item.Id = _nextId++;
            questions.Add(item);
            return item;
        }

        public IEnumerable<Question> GetSurveyQuestions(int id)
        {
            return questions.FindAll(p => p.SurveyId == id);
        }

    }
}
