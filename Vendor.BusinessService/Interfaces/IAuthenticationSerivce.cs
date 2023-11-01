using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.BusinessEntities.Models;

namespace Vendor.BusinessService.Interfaces
{
    public interface IAuthenticationSerivce
    {
        Task<string> Register(RegistrationRequest request);
        Task<string> Login(LoginRequest request);
    }
}
