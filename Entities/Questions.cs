using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class Questions
    {
        public Questions()
        {
            QuestionsAnswers = new HashSet<QuestionsAnswers>();
        }

        public int QuestionId { get; set; }
        public int? QuizId { get; set; }
        public string Question { get; set; }
        public byte[] QuestionMedia { get; set; }

        public virtual Quizzes Quiz { get; set; }
        public virtual ICollection<QuestionsAnswers> QuestionsAnswers { get; set; }
    }
}
