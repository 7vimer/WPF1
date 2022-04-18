using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp5.SQL
{
    public partial class Model1 : DbContext
    {
        private static Model1 context;
        public Model1()
            : base("name=Model1")
        {
        }
        public static Model1 GetContext()
        {
            if (context == null) context = new Model1();
            return context;
        }
        public virtual DbSet<Licenses> Licenses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Водители> Водители { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Licenses>()
                .Property(e => e.licenseSeries)
                .IsFixedLength();

            modelBuilder.Entity<Licenses>()
                .Property(e => e.licenseNumber)
                .IsFixedLength();
        }
    }
}
