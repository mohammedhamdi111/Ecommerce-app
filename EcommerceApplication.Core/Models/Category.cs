using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Core.Models
{
    public class Category
    {
        public Category()
        {
            this.Proudcts = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage ="Must enter Category name")]
        [Display(Name ="Name")]
        [MinLength(3),MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Must enter Category Description")]
        [MinLength(5),MaxLength(100)]
        public string Description { get; set; }
        
        public bool IsActive { get; set; } 
        public bool IsDelete { get; set; } 
        public virtual ICollection<Product> Proudcts { get; set; }
      
    }
}
