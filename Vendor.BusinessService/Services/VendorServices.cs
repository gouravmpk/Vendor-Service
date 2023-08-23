using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.BusinessEntities.Models;
using Vendor.BusinessService.Interfaces;

namespace Vendor.BusinessService.Services
{
    public class VendorServices : IVendorInterface
    {
        private readonly IVendorInterface _vendorInterface;
        public VendorServices(IVendorInterface vendorInterface)
        {
            _vendorInterface = vendorInterface;
        }

        public Task<List<VendorsDTO>> GetVendors()
        {
            return _vendorInterface.GetVendors();
        }
    }
}
