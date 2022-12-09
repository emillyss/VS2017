namespace ApplicationEF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEF : DbContext
    {
        public ModelEF()
            : base("name=ModelEF")
        {
        }

        public virtual DbSet<teste> testes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<teste>()
                .Property(e => e.texto)
                .IsUnicode(false);
        }
    }
}
