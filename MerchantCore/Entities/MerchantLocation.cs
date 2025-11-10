using MerchantCore.Comman;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantCore.Entities
{
    public class MerchantLocation : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string? Location { get; set; }
        public int? ParentID { get; set; } // Optional ParentID for hierarchical locations
        public string? Address { get; set; }
        public string? POCName { get; set; }
        public string? POCEmail { get; set; }
        public string? POCNumber { get; set; }
        public string? OtherEmail { get; set; }
        public string? OtherNumber { get; set; }


        // Foreign key property
        public int MerchantId { get; set; }

        // Navigation property - location belongs to one merchant
        public Merchant? Merchant { get; set; }

    }
}
