namespace ApplicationEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("teste")]
    public partial class teste
    {
        public int id { get; set; }

        [StringLength(50)]
        public string texto { get; set; }

        public double? numero { get; set; }

        public DateTime? datahora { get; set; }
    }
}
