using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantCore.Entities
{
    public class Notification
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset OccurredAt { get; set; }
        // Add any other fields you need (e.g., MerchantId, ComplaintId)
    }
}
