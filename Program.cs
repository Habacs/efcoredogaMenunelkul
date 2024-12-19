using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace autokefCore
{
    internal class Program
    {
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Born { get; set; }
        }
        
        public class Car
        {
            public int Id { get; set; }
            public string Brand { get; set; }
            public string Type { get; set; }
            public int RelaseDate { get; set; }
        }
 
        public class UserAndCarContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Car> Cars { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        static void Main(string[] args)
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Date f birth: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Brad: ");
            string brand = Console.ReadLine();
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Relase date (YYYY/MM/DD): ");
            int relaseDate = int.Parse(Console.ReadLine());

            
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Born = dateTime,
            };
            
            Car car = new Car()
            {
                Brand = brand,
                Type = type,
                RelaseDate = relaseDate
            
            };
            
            using(UserAndCarContext context = new UserAndCarContext())
            {
                context.Users.Add(user);
                context.Cars.Add(car);
            }
            Console.ReadLine();
            
       
        }
    }
}
