﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.BusinessEntities.Models;

namespace Vendor.BusinessService.Interfaces
{
    public interface IVendorInterface
    {
        Task<List<VendorsDTO>> GetAllVendors();
        Task<VendorsDTO> GetVendors(int id);
        Task<VendorsDTO> GetVendorByName(string name);

    }
}
