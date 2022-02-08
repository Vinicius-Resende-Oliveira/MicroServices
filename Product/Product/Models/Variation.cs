using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    [Table("Variation")]
    public class Variation
    {
        [Column("VAR_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "PRODUCT")]
        [ForeignKey("Product")]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Column("VAR_NAME")]
        [MaxLength(255)]
        [Display(Name = "NAME")]
        public string Name { get; set; }
        [Column("VAR_QUANTITY")]
        [Display(Name = "QUANTITY")]
        public int Quantity { get; set; }
        [Column("VAR_PRICE")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        public List<Variation> Variations { get; set; }
        [Column("VAR_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate { get; set; }
        [Column("VAR_DATE_UPDATE")]
        [Display(Name = "Date Update")]
        public DateTime DateUpdate { get; set; }

    }
}
