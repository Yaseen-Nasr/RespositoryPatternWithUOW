using Microsoft.EntityFrameworkCore;
using RespositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryPatternWithUOW.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}
