using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Models
{
    public class Product
    {
      
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        [Range(0,100,ErrorMessage ="Invalid Quantity")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public DateTime CreatedDate { get; set; }= DateTime.Now  ;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Categorie")]

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; } 

      
    }
}
