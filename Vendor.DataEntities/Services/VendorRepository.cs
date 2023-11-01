using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public VendorRepository(VendorContext vendorContext)
        {
            _vendorContext = vendorContext;
        }

     
        public async Task<Vendors> GetVendorById(int id)
        {
            try{
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
            catch(Exception ex) { 
            _logger.LogError($"exception occured {ex}");
                return null ;
           }
        }

        public async Task<Vendors> GetVendorByName(string Name) {
            try
            {
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
            catch (Exception ex){
                _logger.LogError($"Exception: {ex}");
                return null;
            }
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
