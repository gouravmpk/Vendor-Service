using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor.DataEnities.Interface;
using Vendor.DataEntities.Models;
 
namespace Vendor.Api.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorController(IVendorRepository vendorRepository) {
            _vendorRepository = vendorRepository;
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

            var vendorResult = await _vendorRepository.GetAll();
            return Ok(vendorResult);
        }
 
    }
}
