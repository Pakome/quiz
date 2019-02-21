using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class Scores
    {
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
        public int ScoreId { get; set; }
        public string QuizTimer { get; set; }

        public virtual Users User { get; set; }
    }
}
