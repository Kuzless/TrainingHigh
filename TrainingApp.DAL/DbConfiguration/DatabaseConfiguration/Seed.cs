using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training__DAL_.Models;

namespace TrainingApp.DAL.DbConfiguration.DatabaseConfiguration
{
    public static class Seed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification()
                {
                    Id = 1,
                    Name = "Professor",
                    Coefficient = 2.0f
                },
                new Qualification()
                {
                    Id = 2,
                    Name = "Doctor",
                    Coefficient = 1.5f
                },
                new Qualification()
                {
                    Id = 3,
                    Name = "Master",
                    Coefficient = 1f
                }
                );
            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    Id = 1,
                    Name = "6.04.01"
                },
                new Group()
                {
                    Id = 2,
                    Name = "6.04.02"
                },
                new Group()
                {
                    Id = 3,
                    Name = "6.04.03"
                }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    GroupId = 1,
                    Name = "Andriy",
                    Address = "Street 1",
                    Email = "andriy@example.com",
                    PhoneNumber = "+380999999991"
                },
                new Student()
                {
                    Id = 2,
                    GroupId = 1,
                    Name = "Alex",
                    Address = "Street 2",
                    Email = "alex@example.com",
                    PhoneNumber = "+380999999992"
                },
                new Student()
                {
                    Id = 3,
                    GroupId = 1,
                    Name = "Anna",
                    Address = "Street 3",
                    Email = "anna@example.com",
                    PhoneNumber = "+380999999993"
                },
                new Student()
                {
                    Id = 4,
                    GroupId = 2,
                    Name = "Boris",
                    Address = "Street 4",
                    Email = "boris@example.com",
                    PhoneNumber = "+380999999994"
                },
                new Student()
                {
                    Id = 5,
                    GroupId = 2,
                    Name = "Bella",
                    Address = "Street 5",
                    Email = "bella@example.com",
                    PhoneNumber = "+380999999995"
                },
                new Student()
                {
                    Id = 6,
                    GroupId = 2,
                    Name = "Ben",
                    Address = "Street 6",
                    Email = "ben@example.com",
                    PhoneNumber = "+380999999996"
                },
                new Student()
                {
                    Id = 7,
                    GroupId = 3,
                    Name = "Charlie",
                    Address = "Street 7",
                    Email = "charlie@example.com",
                    PhoneNumber = "+380999999997"
                },
                new Student()
                {
                    Id = 8,
                    GroupId = 3,
                    Name = "Chloe",
                    Address = "Street 8",
                    Email = "chloe@example.com",
                    PhoneNumber = "+380999999998"
                },
                new Student()
                {
                    Id = 9,
                    GroupId = 3,
                    Name = "Chris",
                    Address = "Street 9",
                    Email = "chris@example.com",
                    PhoneNumber = "+380999999999"
                }
               );
            modelBuilder.Entity<TeacherInfo>().HasData(
                new TeacherInfo()
                {
                    Id = 1,
                    Name = "Shevchenko D.I",
                    Address = "Gagarina Street 3",
                    PhoneNumber = "+380999999991",
                    Email = "shev1@gmail.com",
                    QualificationId = 1
                },
                new TeacherInfo()
                {
                    Id = 2,
                    Name = "Ivanenko A.V",
                    Address = "Lenina Street 4",
                    PhoneNumber = "+380999999992",
                    Email = "ivan1@gmail.com",
                    QualificationId = 1
                },
                new TeacherInfo()
                {
                    Id = 3,
                    Name = "Petrova L.M",
                    Address = "Pushkina Street 5",
                    PhoneNumber = "+380999999993",
                    Email = "petro1@gmail.com",
                    QualificationId = 2
                },
                new TeacherInfo()
                {
                    Id = 4,
                    Name = "Sidorov G.P",
                    Address = "Kirova Street 6",
                    PhoneNumber = "+380999999994",
                    Email = "sidor1@gmail.com",
                    QualificationId = 2
                },
                new TeacherInfo()
                {
                    Id = 5,
                    Name = "Kuznetsova S.I",
                    Address = "Chekhova Street 7",
                    PhoneNumber = "+380999999995",
                    Email = "kuzne1@gmail.com",
                    QualificationId = 3
                },
                new TeacherInfo()
                {
                    Id = 6,
                    Name = "Morozov V.K",
                    Address = "Tolstogo Street 8",
                    PhoneNumber = "+380999999996",
                    Email = "moroz1@gmail.com",
                    QualificationId = 3
                }
                );
            modelBuilder.Entity<SubjectName>().HasData(
                new SubjectName()
                {
                    Id = 1,
                    Name = "Math"
                },
                new SubjectName()
                {
                    Id = 2,
                    Name = "Literature"
                },
                new SubjectName()
                {
                    Id = 3,
                    Name = "Chemistry"
                },
                new SubjectName()
                {
                    Id = 4,
                    Name = "Biology"
                }
                );
            modelBuilder.Entity<SubjectType>().HasData(
                new SubjectType()
                {
                    Id = 1,
                    Type = "Practice"
                },
                new SubjectType()
                {
                    Id = 2,
                    Type = "Lecture"
                });
            modelBuilder.Entity<SubjectTariff>().HasData(
                new SubjectTariff()
                {
                    Id = 1,
                    subjectNameId = 1,
                    subjectTypeId = 1,
                    PricePerHour = 400
                },
                new SubjectTariff()
                { 
                    Id = 2,
                    subjectNameId = 2,
                    subjectTypeId = 1,
                    PricePerHour = 350
                },
                new SubjectTariff()
                {
                    Id = 3,
                    subjectNameId = 1,
                    subjectTypeId = 2,
                    PricePerHour = 300
                },
                new SubjectTariff()
                {
                    Id = 4,
                    subjectNameId = 2,
                    subjectTypeId = 2,
                    PricePerHour = 250
                },
                new SubjectTariff()
                {
                    Id = 5,
                    subjectNameId = 3,
                    subjectTypeId = 1,
                    PricePerHour = 200
                },
                new SubjectTariff()
                {
                    Id = 6,
                    subjectNameId = 4,
                    subjectTypeId = 2,
                    PricePerHour = 150
                }
                );
        }
    }
}
