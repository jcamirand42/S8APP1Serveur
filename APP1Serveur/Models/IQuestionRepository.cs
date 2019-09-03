using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP1Serveur.Models
{
    interface IQuestionRepository
    {
        IEnumerable<Question> GetSurveyQuestions(int id);
        Question Add(Question item);
    }
}
