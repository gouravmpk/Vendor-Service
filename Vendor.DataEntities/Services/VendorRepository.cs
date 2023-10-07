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

     
        public async Task<Vendors> GetVendors(int id)
        {
            var result = await _vendorContext.Vendors.AsNoTracking()
                  .Where(x => x.VendorID == id)
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
                  }).FirstOrDefaultAsync(); 
             
            return result;
        }

        public async Task<Vendors> GetVendorByName(string Name) {
            var result = await _vendorContext.Vendors.AsNoTracking()
                    .Where(x => x.VendorName == Name)
                    .Select(x => new Vendors
                    {
                        VendorID = x.VendorID,
                        VendorLocation = x.VendorLocation,
                        VendorName = x.VendorName,
                        VerificationStatus = x.VerificationStatus,
                        ContactInfo = x.ContactInfo,
                        Notifications = x.Notifications,
                        Products = x.Products
                    }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Vendors>> GetAllVendors()
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
