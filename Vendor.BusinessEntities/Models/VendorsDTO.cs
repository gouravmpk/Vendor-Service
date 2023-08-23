using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.BusinessEntities.Models
{
    public class VendorsDTO
    {
        [Key]
        public int VendorID { get; set; }
        public string? VendorName { get; set; }
        public string? ContactInfo { get; set; }
        public bool VerificationStatus { get; set; }
        public string? VendorLocation { get; set; }
        public string? VendorType { get; set; }
    }
}
