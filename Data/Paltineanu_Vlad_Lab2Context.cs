using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paltineanu_Vlad_Lab2.Models;

namespace Paltineanu_Vlad_Lab2.Data
{
    public class Paltineanu_Vlad_Lab2Context : DbContext
    {
        public Paltineanu_Vlad_Lab2Context (DbContextOptions<Paltineanu_Vlad_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Paltineanu_Vlad_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Paltineanu_Vlad_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Paltineanu_Vlad_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Paltineanu_Vlad_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Paltineanu_Vlad_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Paltineanu_Vlad_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
