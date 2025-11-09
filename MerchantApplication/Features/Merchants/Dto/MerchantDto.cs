using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.Merchants.Dto
{
    public class MerchantDto
    {
        public int ID { get; set; }
        public string MerchantCode { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantAddress { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? OtherEmail { get; set; }
        public string? Number { get; set; }
        public string? OtherNumber { get; set; }
        public string City { get; set; } = string.Empty;
        public int Area { get; set; }
        public int Zone { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        // Optional audit metadata (if you want to include)
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
