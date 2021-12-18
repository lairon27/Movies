using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cinema.Model
{
    internal class MovieContext : DbContext
    {
        public MovieContext() : base("DefaultConnection")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
