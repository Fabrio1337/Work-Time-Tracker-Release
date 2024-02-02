using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WorkTimeTracker
{
    internal class Cont : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ses> Sessions { get; set; }
        public Cont() :base("WTTdb") { }
    }
}
