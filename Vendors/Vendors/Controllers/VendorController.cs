using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendors.Models;
using Vendors.Data;

namespace Vendors.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly ApiContext _context;

        public VendorController(ApiContext context)
        {
            _context = context;
        }

        //Post
        [HttpPost]
        public JsonResult CreateEdit(VendorDetails VDetails) {
            if (VDetails.VendorID == 0) { _context.Vendors.Add(VDetails); }
            else {

                throw new NotSupportedException("Error message");
                
            }
            _context.SaveChanges();
            return new JsonResult(Ok(VDetails));
        }

        //get
        [HttpGet]
        public JsonResult Get(int num) {
            var result = _context.Vendors.Find(num);
            if (result == null) return new JsonResult(NotFound());
            return new JsonResult(Ok(result));
        }

        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Vendors.ToList();
            return new JsonResult(Ok(result));
        }

        [HttpPut]
        public IActionResult Update(int num, [FromBody] VendorDetails updatedVendor)
        {
            var existingVendor = _context.Vendors.Find(num);
            if (existingVendor == null)
            {
                return NotFound();
            }

            _context.Entry(existingVendor).CurrentValues.SetValues(updatedVendor);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public JsonResult Delete(int num) {
            var result = _context.Vendors.Find(num);
            if (result == null) return new JsonResult(NotFound());
            _context.Vendors.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

    }
}
