using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.DataEnities.Interface;
using Vendor.DataEntities;
using Vendor.DataEntities.Models;

namespace Vendor.DataEnities.Services
{
    public class VendorRepository : IVendorRepository
    {
        private readonly VendorContext _vendorContext;

        public VendorRepository(VendorContext vendorContext)
        {
            _vendorContext = vendorContext;
        }

     
        public async Task<List<Vendors>> GetAll()
        {
            var result = await _vendorContext.Vendors.AsNoTracking()
                .Select(x => new Vendors
                {
                    VendorID = x.VendorID,
                    VendorLocation = x.VendorLocation,
                    VendorName = x.VendorName,
                    VerificationStatus = x.VerificationStatus,
                    ContactInfo = x.ContactInfo,
                    VendorType = x.VendorType,
                    Notifications = x.Notifications,
                    Products = x.Products
                }).ToListAsync();

            return result;
        }

      
    }
}
