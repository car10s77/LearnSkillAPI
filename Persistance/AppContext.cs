using LearnASkill.Models;
using LearnASkill.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearnASkill.Persistance;

public class AppContext : DbContext
{
    public AppContext()
    {

    }
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<UserGoal> UsersGoals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Goals Skills Relation
        modelBuilder.Entity<Goal>()
            .HasOne(g => g.Skill)
            .WithMany(s => s.Goals)
            .HasForeignKey(g => g.SkillId);

        // Users Goals relation throught UsersGoals
        modelBuilder.Entity<UserGoal>()
            .HasKey(ug => ug.Id);

        modelBuilder.Entity<UserGoal>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UsersGoals)
            .HasForeignKey(ug => ug.UserId);

        modelBuilder.Entity<UserGoal>()
            .HasOne(ug => ug.Goal)
            .WithMany(g => g.UsersGoals)
            .HasForeignKey(ug => ug.GoalId);

        // User Seeds
        modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = 1,
            Name = "Homer",
            LastName = "Simpson",
            UserName = "mrX",
            Password = HashService.HashPassword("pass123"),
            UserEmail = "homer_simpson@email.com",
            City = "Springfield"
        });

        // Skills seeds
        modelBuilder.Entity<Skill>().HasData(
        new Skill
        {
            Id = 1,
            Name = "Learn English",
            Description = "Learn a new language"
        },
        new Skill
        {
            Id = 2,
            Name = "Programming",
            Description = "Learn to code on C# language"
        },
        new Skill
        {
            Id = 3,
            Name = "Play the Guitar",
            Description = "Master the art of playing the guitar"
        },
        new Skill
        {
            Id = 4,
            Name = "Data Science",
            Description = "Explore the world of data science"
        },
        new Skill
        {
            Id = 5,
            Name = "Fitness Training",
            Description = "Achieve peak fitness levels"
        });

        // Goals seeds
        modelBuilder.Entity<Goal>().HasData(
        new Goal
        {
            Id = 1,
            Name = "Begginer's vocabulary",
            SkillId = 1,
            Dificulty = 1
        },
        new Goal
        {
            Id = 2,
            Name = "Conversation Proficiency",
            SkillId = 1,
            Dificulty = 2
        },
        new Goal
        {
            Id = 3,
            Name = "Advance skills",
            SkillId = 1,
            Dificulty = 3
        },
        new Goal
        {
            Id = 4,
            Name = "C# 101. Basics",
            SkillId = 2,
            Dificulty = 1
        },
        new Goal
        {
            Id = 5,
            Name = "OOP. Write a console APP",
            SkillId = 2,
            Dificulty = 2
        },
        new Goal
        {
            Id = 6,
            Name = "API. Code a web service",
            SkillId = 2,
            Dificulty = 3
        },
        new Goal
        {
            Id = 7,
            Name = "Chords Mastery",
            SkillId = 3,
            Dificulty = 1
        },
        new Goal
        {
            Id = 8,
            Name = "Play a Song",
            SkillId = 3,
            Dificulty = 2
        },
        new Goal
        {
            Id = 9,
            Name = "Advanced Techniques",
            SkillId = 3,
            Dificulty = 3
        },
        new Goal
        {
            Id = 10,
            Name = "Intermediate Data Analysis",
            SkillId = 4,
            Dificulty = 1
        },
        new Goal
        {
            Id = 11,
            Name = "Machine Learning Basics",
            SkillId = 4,
            Dificulty = 2
        },
        new Goal
        {
            Id = 12,
            Name = "Build a Predictive Model",
            SkillId = 4,
            Dificulty = 3
        });
    }
}
