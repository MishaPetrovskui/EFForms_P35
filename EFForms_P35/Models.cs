using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFForms_P35.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Curator Curator { get; set; }
        public override string ToString()
        {
            return $"{Name} (ID:{Id})";
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }
        public int AVG { get; set; }
        public override string ToString()
        {
            return $"{Name} (ID:{Id})";
        }
    }
    
    public class Curator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name} (ID:{Id})";
        }
    }

    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Curator> Curators { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=university;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    /*public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=notes;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }*/
}
