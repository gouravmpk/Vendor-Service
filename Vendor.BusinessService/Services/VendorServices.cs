using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.BusinessEntities.Models;
using Vendor.BusinessService.Interfaces;
using Vendor.DataEnities.Interface;
using Vendor.DataEnities.Services;


namespace Vendor.BusinessService.Services
{
    public class VendorServices : IVendorService
    {
        private readonly IVendorRepository _vendorRepo;
        private readonly IMapper _mapper; // Add IMapper dependency

        public VendorServices(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepo = vendorRepository;
            _mapper = mapper;
        }

        public async Task<List<VendorsDTO>> GetAllVendors()
        {
            var vendors = await _vendorRepo.GetAllVendors();
            var vendorDTOs = _mapper.Map<List<VendorsDTO>>(vendors);
            return vendorDTOs;
        }

        public async Task<VendorsDTO> GetVendorByName(string name)
        {
            var vendor = await _vendorRepo.GetVendorByName(name);
            var vendorDTO = _mapper.Map<VendorsDTO>(vendor);
            return vendorDTO;
        }

        public async Task<VendorsDTO> GetVendors(int id)
        {
            var vendor = await _vendorRepo.GetVendorById(id);
            var vendorDTO = _mapper.Map<VendorsDTO>(vendor);
            return vendorDTO;
        }
    }
}