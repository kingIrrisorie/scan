using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using scan.Models;

namespace scan.Context
{
    public class IronicusScanContext : DbContext
    {
        public IronicusScanContext(DbContextOptions<IronicusScanContext> options) : base(options){}

        public DbSet<Manga> Mangas {get; set;}
    }
}