using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class Quizzes
    {
        public Quizzes()
        {
            Questions = new HashSet<Questions>();
        }

        public int QuizId { get; set; }
        public int? SessionId { get; set; }
        public string QuizName { get; set; }
        public string QuizDescription { get; set; }
        public string QuizTheme { get; set; }

        public virtual Sessions Session { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
