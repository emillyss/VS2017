namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
