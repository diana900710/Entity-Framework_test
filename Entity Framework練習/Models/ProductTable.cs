namespace Entity_Framework練習.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductTable")]
    public partial class ProductTable
    {
        [Key]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string ProductType { get; set; }
    }
}
