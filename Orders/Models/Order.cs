using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Models
{
    [Table("Order")]
    public class Order
    {
        [Column("ORDER_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "CUSTOMER")]
        [ForeignKey("ORDER_Customer")]
        [Column(Order = 1)]
        public int CustomerId { get; set; }
        public virtual Customer Customer{ get; set; }
        public StatusOrder Status { get; set; }
        [Column("ORDER_TOTAL_PRICE")]
        [Display(Name = "TotalPrice")]
        public decimal TotalPrice { get; set; }
        [Column("ORDER_DISCOUNT")]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
        [Column("ORDER_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate{ get; set; }
        [Column("ORDER_DATE_UPDATE")]
        [Display(Name = "Date Update")]
        public DateTime DateUpdate{ get; set; }

        public List<Product> Product { get; set; }
    }
}
