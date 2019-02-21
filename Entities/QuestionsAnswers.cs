using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class QuestionsAnswers
    {
        public int QuestionAnswerId { get; set; }
        public int? QuestionId { get; set; }
        public string QuestionAnswer { get; set; }
        public byte? QuestionAnswerRight { get; set; }

        public virtual Questions Question { get; set; }
    }
}
