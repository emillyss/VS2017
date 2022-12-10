namespace Infra
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;

    public partial class ModelEF : DbContext
    {
        private static string conn = "data source = SQL8003.site4now.net; initial catalog = db_a913e2_senai09113271; persist security info=True;user id = db_a913e2_senai09113271_admin; password=senai09113271;MultipleActiveResultSets=True;App=EntityFramework";
        public ModelEF()
            : base(conn)
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
