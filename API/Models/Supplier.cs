using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name must be at least 6 characters")]
        //[RegularExpression("^[A-Za-z]*$", ErrorMessage = "Name must be characters or charactres with numbers")]
        public string SupplierName { get; set; }
    }
}