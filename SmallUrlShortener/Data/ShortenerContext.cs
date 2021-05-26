using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallUrlShortener.Data
{
    public class ShortenerContext: DbContext
    {
        public ShortenerContext(DbContextOptions<ShortenerContext> options) : base(options)
        {
        }

        public DbSet<UrlMapping> UrlMappings { get; set; }
    }
}
