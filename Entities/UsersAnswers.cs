using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class UsersAnswers
    {
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public string QuizId { get; set; }
        public string QuestionId { get; set; }
        public string QuestionAnswerId { get; set; }
    }
}
