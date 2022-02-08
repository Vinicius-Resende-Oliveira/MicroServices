using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customers.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Column("CUST_ID")]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Column("CUST_NAME")]
        [MaxLength(255)]
        [Display(Name = "NAME")]
        public string Name { get; set; }
        [Column("CUST_AGE")]
        [Display(Name = "AGE")]
        public int Age { get; set; }
        [Column("CUST_DATE_CREATE")]
        [Display(Name = "Date Create")]
        public DateTime DateCreate { get; set; }
        [Column("CUST_DATE_UPDATE")]
        [Display(Name = "Date Update")]
        public DateTime DateUpdate{ get; set; }
    }
}
