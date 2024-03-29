﻿// <auto-generated />
using System;
using LearnASkill.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearnASkill.Persistance.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearnASkill.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Dificulty")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dificulty = 1,
                            Name = "Begginer's vocabulary",
                            SkillId = 1
                        },
                        new
                        {
                            Id = 2,
                            Dificulty = 2,
                            Name = "Conversation Proficiency",
                            SkillId = 1
                        },
                        new
                        {
                            Id = 3,
                            Dificulty = 3,
                            Name = "Advance skills",
                            SkillId = 1
                        },
                        new
                        {
                            Id = 4,
                            Dificulty = 1,
                            Name = "C# 101. Basics",
                            SkillId = 2
                        },
                        new
                        {
                            Id = 5,
                            Dificulty = 2,
                            Name = "OOP. Write a console APP",
                            SkillId = 2
                        },
                        new
                        {
                            Id = 6,
                            Dificulty = 3,
                            Name = "API. Code a web service",
                            SkillId = 2
                        },
                        new
                        {
                            Id = 7,
                            Dificulty = 1,
                            Name = "Chords Mastery",
                            SkillId = 3
                        },
                        new
                        {
                            Id = 8,
                            Dificulty = 2,
                            Name = "Play a Song",
                            SkillId = 3
                        },
                        new
                        {
                            Id = 9,
                            Dificulty = 3,
                            Name = "Advanced Techniques",
                            SkillId = 3
                        },
                        new
                        {
                            Id = 10,
                            Dificulty = 1,
                            Name = "Intermediate Data Analysis",
                            SkillId = 4
                        },
                        new
                        {
                            Id = 11,
                            Dificulty = 2,
                            Name = "Machine Learning Basics",
                            SkillId = 4
                        },
                        new
                        {
                            Id = 12,
                            Dificulty = 3,
                            Name = "Build a Predictive Model",
                            SkillId = 4
                        });
                });

            modelBuilder.Entity("LearnASkill.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learn a new language",
                            Name = "Learn English"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Learn to code on C# language",
                            Name = "Programming"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Master the art of playing the guitar",
                            Name = "Play the Guitar"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Explore the world of data science",
                            Name = "Data Science"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Achieve peak fitness levels",
                            Name = "Fitness Training"
                        });
                });

            modelBuilder.Entity("LearnASkill.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Springfield",
                            LastName = "Simpson",
                            Name = "Homer",
                            Password = "m4dppKdClZotApjDb7cGI/LfrNqENiN98I2N/Vs3N0w=",
                            UserEmail = "homer_simpson@email.com",
                            UserName = "mrX"
                        });
                });

            modelBuilder.Entity("LearnASkill.Models.UserGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FinalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GoalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("InitialDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersGoals");
                });

            modelBuilder.Entity("LearnASkill.Models.Goal", b =>
                {
                    b.HasOne("LearnASkill.Models.Skill", "Skill")
                        .WithMany("Goals")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("LearnASkill.Models.UserGoal", b =>
                {
                    b.HasOne("LearnASkill.Models.Goal", "Goal")
                        .WithMany("UsersGoals")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnASkill.Models.User", "User")
                        .WithMany("UsersGoals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnASkill.Models.Goal", b =>
                {
                    b.Navigation("UsersGoals");
                });

            modelBuilder.Entity("LearnASkill.Models.Skill", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("LearnASkill.Models.User", b =>
                {
                    b.Navigation("UsersGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
