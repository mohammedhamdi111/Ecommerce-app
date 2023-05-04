using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Models
{
    public class OrderTable
    {
        public int Id { get; set; }
        [ForeignKey("address")]
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public DateTime ShippingDate { get; set; }
        public bool IsDelivered { get; set; }
      
        public virtual Address address { get; set; }
    }
}
