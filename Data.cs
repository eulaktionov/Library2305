using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic.ApplicationServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations;

namespace Library2305
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; } = new();

        public override string ToString()
        {
            return $"{LastName} {FirstName ?? string.Empty}";
        }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
    public class Record
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Книга обязательна")]
        public Book Book { get; set; }
        [Required(ErrorMessage = "Читатель обязателен")]
        public Reader Reader { get; set; }
        public DateTime ReceiveDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public override string ToString()
        {
            return $"{Book} {Reader} {ReceiveDate} {ReturnDate}";
        }
    }

    public class Data : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Record> Records { get; set; }

        public Data(DbContextOptions<Data> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
    public class ContextFactory : IDesignTimeDbContextFactory<Data>
    {
        public Data CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Data>();
            ConfigurationBuilder builder = new();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString); 
            return new Data(optionsBuilder.Options);
        }
    }
}
