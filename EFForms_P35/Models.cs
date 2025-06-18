using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFForms_P35.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int QuantityInStock { get; set; }

        public override string ToString()
        {
            return $"{Id, 2}. {Name, 8}: {Price, 5}; {QuantityInStock, 4} - {Category}";
        }
    }

    public class Сlients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public override string ToString()
        {
            return $"{Id,2}. {Name,8} {Surname,8}: {ContactNumber}";
        }
    }
    
    public class Orders
    {
        public int Id { get; set; }
        public Сlients Сlients { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"{Id,2}. {Сlients,8}: {Status,5}; {DateOfRegistration}";
        }
    }

    public class OrderDetails
    {
        public int Id { get; set; }
        public Goods Goods { get; set; }
        public Orders Orders { get; set; }
        public double TotalAmount { get; set; }
        public override string ToString()
        {
            return $"{Id,2}. {Goods,8}: {Orders,5}; {TotalAmount}";
        }
    }

    public class Payment
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Orders Orders { get; set; }
        public override string ToString()
        {
            return $"{Id,2}. {Orders,8}: {Sum,5}; {PaymentMethod}; {DateOfPayment}";
        }

    }

    public class UniversityContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Сlients> Сlients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=shop;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
