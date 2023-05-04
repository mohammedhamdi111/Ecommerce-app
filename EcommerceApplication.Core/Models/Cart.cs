using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("CartStatues")]
        public int CartStatusId { get; set; }
        public virtual CartStatues CartStatues { get; set; }
        public virtual Product Product { get; set; }
    }
}
