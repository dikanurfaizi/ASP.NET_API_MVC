using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [StringLength(50)]
        public string ItemName { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid manipulate data, input must be numbers")]
        public int Quantity { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Price must be numbers")]
        public int Price { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}