using System.ComponentModel.DataAnnotations;

namespace Vendors.Models
{
    public class VendorDetails
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string VendorContact { get; set; }
        public VCategory VendorCategory { get; set; }
        public Vtype VendorType { get; set; }
        public string VendorReferedBy { get; set; }
    }
}
