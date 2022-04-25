using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Techdome.API.Model.Members;

namespace Techdome.API.Model
{
    public class InlineDatabaseContext : DbContext
    {
        /*public InlineDatabaseContext(DbContextOptions options): base(options)
        {
        }*/
        public DbSet<Members.Member> Config { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseInMemoryDatabase("MyDatabase");
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("MyDatabase");
        }*/
    }
}
