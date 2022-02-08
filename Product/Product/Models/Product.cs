using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("PROD_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Column("PROD_NAME")]
        [MaxLength(255)]
        [Display(Name = "NAME")]
        public string Nome { get; set; }
        [Column("PROD_DESCRIPTION")]
        [MaxLength(150)]
        [Display(Name = "DESCRIPTION")]
        public string Description { get; set; }
        [Column("PROD_NOTE")]
        [MaxLength(20000)]
        [Display(Name = "NOTE")]
        public string Note { get; set; }
        [Column("PROD_QUANTITY")]
        [Display(Name = "QUANTITY")]
        public int Quantity { get; set; }
        [Column("PROD_PRICE")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        public List<Variation> Variations { get; set; }
        [Column("PROD_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate { get; set; }
        [Column("PROD_DATE_UPDATE")]
        [Display(Name = "Date Update")]
        public DateTime DateUpdate { get; set; }

    }
}
