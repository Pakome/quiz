using System;
using System.Collections.Generic;

namespace QuizGenerator.Entities
{
    public partial class Users
    {
        public Users()
        {
            Scores = new HashSet<Scores>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        public byte[] Selfie { get; set; }
        public int? Admin { get; set; }
        public int? Activity { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Scores> Scores { get; set; }
    }
}
