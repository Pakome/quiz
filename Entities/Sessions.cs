using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class Sessions
    {
        public Sessions()
        {
            Quizzes = new HashSet<Quizzes>();
        }

        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionEventName { get; set; }
        public string SessionLocalisation { get; set; }
        public DateTime? SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }

        public virtual ICollection<Quizzes> Quizzes { get; set; }
    }
}
