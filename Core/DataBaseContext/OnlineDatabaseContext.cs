using Core.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataBaseContext
{
   public class OnlineDatabaseContext : DbContext
    {
        public OnlineDatabaseContext()//razor.design
        {

        }

        public OnlineDatabaseContext(DbContextOptions<OnlineDatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<IstekveSikayet> IstekveSikayet { get; set; }
        public DbSet<Kelimeler> Kelimeler { get; set; }
    }
}
