using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Models
{
    public class OrderDetials
    {
        public int Id { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        [ForeignKey("OrderTable")]
        public int OrderId { get; set; }
        public decimal SubTotal { get; set; }
        public virtual Product product { get; set; }
        public virtual OrderTable OrderTable { get; set; }


    }
}
