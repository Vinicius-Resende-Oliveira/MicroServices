using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Models
{
    [Table("ORDER_Customer")]
    public class Customer
    {
        [Column("CUST_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Column("CUST_NAME")]
        [MaxLength(255)]
        [Display(Name = "NAME")]
        public string Name { get; set; }
        [Column("CUST_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate { get; set; }
    }
}
