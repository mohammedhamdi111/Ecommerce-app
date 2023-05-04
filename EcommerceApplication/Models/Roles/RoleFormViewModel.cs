
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Roles
{
    public class RoleFormViewModel
    {
        [StringLength(256)]
        public string Name { get; set; }
    }
}
