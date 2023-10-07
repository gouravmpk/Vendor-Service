using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor.BusinessService.Interfaces;
using Vendor.DataEnities.Interface;
using Vendor.DataEntities.Models;
 
namespace Vendor.Api.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorInterface _vendorInterface;

        public VendorController(IVendorInterface vendorInterface) {
            _vendorInterface = vendorInterface;
        }
        // GET: VendorController
       
        [HttpGet]
        [Route("[controller]")]
        [ProducesResponseType(200,Type= typeof(List<Vendors>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult> GetAllVendor()
        {

            var vendorResult = await _vendorInterface.GetAllVendors();
            return Ok(vendorResult);
        }

        [HttpGet]
        public  async Task<ActionResult> GetVendor(int vendorId)
        {
            var vendorResult = await _vendorInterface.GetVendors(vendorId);
            return Ok(vendorResult);
        }

        [HttpGet]
        public async Task<ActionResult> GetVendorByName(string Name) {
            var vendorResult = await _vendorInterface.GetVendorByName(Name);
            return Ok(vendorResult);
        }
        
        
 
    }
}
