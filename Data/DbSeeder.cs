using Bogus;
using OOP_final.Components.Models;
using System;

namespace OOP_final.Components.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Employees.Any())
                return; 

            var faker = new Faker();
            var employees = new List<Employee>();

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    employees.Add(new Fulltime
                    {
                        Name = faker.Name.FullName(),
                        Email = faker.Internet.Email(),
                        Position = faker.Name.JobTitle(),
                        AnnualSalary = faker.Random.Int(30000, 120000)
                    });
                }
                else
                {
                    employees.Add(new Parttime
                    {
                        Name = faker.Name.FullName(),
                        Email = faker.Internet.Email(),
                        Position = faker.Name.JobTitle(),
                        HourlyRate = faker.Random.Int(15, 50),
                        HoursPerWeek = faker.Random.Int(10, 40)
                    });
                }
            }

            db.Employees.AddRange(employees);
            db.SaveChanges();
        }
    }
}
