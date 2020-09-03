using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Article.Entities;

namespace Article
{
    public class ArticlesDbContext : DbContext
    {
        public DbSet<Articles> Articles { get; set; }

        public ArticlesDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
