using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.ManagementHierarchies.Dto
{
    public class ManagementHierarchyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? POCName { get; set; }
        public string? Name { get; set; }
        public string? POCEmail { get; set; }
        public string? POCNumber { get; set; }
        public string? OtherEmail { get; set; }
        public string? OtherContact { get; set; }
        public string? Address { get; set; }
        public int? ParentID { get; set; }
        public int ManagementType { get; set; }  ///
    }
}
