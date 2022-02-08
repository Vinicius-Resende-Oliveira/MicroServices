using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Models
{
    [Table("ORDER_Product")]
    public class Product
    {
        [Column("PROD_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ORDER")]
        [ForeignKey("Order")]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order{ get; set; }
        [Column("PROD_NAME")]
        [MaxLength(255)]
        [Display(Name = "NAME")]
        public string Nome { get; set; }
        [Column("PROD_QUANTITY")]
        [Display(Name = "QUANTITY")]
        public int Quantity { get; set; }
        [Column("PROD_PRICE")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Column("PROD_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate { get; set; }
    }
}
