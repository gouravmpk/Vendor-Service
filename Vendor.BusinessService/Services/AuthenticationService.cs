using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.BusinessEntities.Models;
using Vendor.BusinessService.Interfaces;
using Vendor.DataEnities.Interface;
using Vendor.DataEnities.Services;
using Vendor.DataEntities.Models;

namespace Vendor.BusinessService.Services
{
    public class AuthenticationService : IAuthenticationSerivce
    {
        private readonly IVendorRepository _vendorRepo;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IVendorRepository vendors, IConfiguration configuration)
        {
            _vendorRepo = vendors;
            _configuration = configuration;
        }
        Task<string> IAuthenticationSerivce.Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        Task<string> IAuthenticationSerivce.Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
