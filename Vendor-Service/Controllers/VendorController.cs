using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor.BusinessService.Interfaces;
using Vendor.DataEnities.Interface;
using Vendor.DataEntities.Models;
 
namespace Vendor.Api.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorInterface) {
            _vendorService = vendorInterface;
        }
        // GET: VendorController
       
        [HttpGet]
        [Route("vendors")]
        [ProducesResponseType(200,Type= typeof(List<Vendors>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult> GetAllVendor()
        {

            var vendorResult = await _vendorService.GetAllVendors();
            return Ok(vendorResult);
        }
        
        [HttpGet]
        [Route("vendor/{vendorId}")]
        public  async Task<ActionResult> GetVendor(int vendorId)
        {
            var vendorResult = await _vendorService.GetVendors(vendorId);
            return Ok(vendorResult);
        }

        [HttpGet]
        [Route("vendor/byName/{name}")]
        public async Task<ActionResult> GetVendorByName(string name) {
            var vendorResult = await _vendorService.GetVendorByName(name);
            return Ok(vendorResult);
        }
        
        
 
    }
}
