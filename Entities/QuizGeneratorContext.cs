using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizGenerator.Entities
{
    public partial class QuizGeneratorContext : DbContext
    {
        public QuizGeneratorContext()
        {
        }

        public QuizGeneratorContext(DbContextOptions<QuizGeneratorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionsAnswers> QuestionsAnswers { get; set; }
        public virtual DbSet<Quizzes> Quizzes { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAnswers> UsersAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("QuizGeneratorDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("questions", "QuizGenerator");

                entity.HasIndex(e => e.QuizId)
                    .HasName("quiz_id_idx");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionMedia)
                    .HasColumnName("question_media")
                    .HasColumnType("blob");

                entity.Property(e => e.QuizId)
                    .HasColumnName("quiz_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("quiz_id");
            });

            modelBuilder.Entity<QuestionsAnswers>(entity =>
            {
                entity.HasKey(e => e.QuestionAnswerId);

                entity.ToTable("questions_answers", "QuizGenerator");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("question_id_idx");

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnName("question_answer_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionAnswer)
                    .HasColumnName("question_answer")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionAnswerRight)
                    .HasColumnName("question_answer_right")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionsAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("question_id");
            });

            modelBuilder.Entity<Quizzes>(entity =>
            {
                entity.HasKey(e => e.QuizId);

                entity.ToTable("quizzes", "QuizGenerator");

                entity.HasIndex(e => e.SessionId)
                    .HasName("session_id_idx");

                entity.Property(e => e.QuizId)
                    .HasColumnName("quiz_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuizDescription)
                    .HasColumnName("quiz_description")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuizName)
                    .HasColumnName("quiz_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuizTheme)
                    .HasColumnName("quiz_theme")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("session_id");
            });

            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasKey(e => e.ScoreId);

                entity.ToTable("scores", "QuizGenerator");

                entity.HasIndex(e => e.QuizId)
                    .HasName("quiz_id_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id_idx");

                entity.Property(e => e.ScoreId)
                    .HasColumnName("score_id")
                    .HasColumnType("int(11) unsigned");

                entity.Property(e => e.QuizId)
                    .HasColumnName("quiz_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuizTimer)
                    .HasColumnName("quiz_timer")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_id");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.ToTable("sessions", "QuizGenerator");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.SessionEnd).HasColumnName("session_end");

                entity.Property(e => e.SessionEventName)
                    .HasColumnName("session_event_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SessionLocalisation)
                    .HasColumnName("session_localisation")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SessionName)
                    .HasColumnName("session_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SessionStart).HasColumnName("session_start");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users", "QuizGenerator");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activity)
                    .HasColumnName("activity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasColumnType("blob");

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("password_salt")
                    .HasColumnType("blob");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Selfie)
                    .HasColumnName("selfie")
                    .HasColumnType("blob");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersAnswers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users_answers", "QuizGenerator");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionAnswerId)
                    .HasColumnName("question_answer_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuizId)
                    .HasColumnName("quiz_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
