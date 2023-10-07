using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.DataEntities.Models;

namespace Vendor.DataEnities.Interface
{
    public interface IVendorRepository
    {
        
        Task<List<Vendors>> GetAllVendors();
        Task<Vendors> GetVendorById(int id);
        Task<Vendors> GetVendorByName(string name);

    }
}
