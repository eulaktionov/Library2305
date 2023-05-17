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

namespace Library2305
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; } = new();
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new();
    }
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Record
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime? ReturnDate { get; set; }
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
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString); 
                //opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new Data(optionsBuilder.Options);
        }
    }
}
