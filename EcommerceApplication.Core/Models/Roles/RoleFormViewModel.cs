
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Core.Models.Roles
{
    public class RoleFormViewModel
    {
        [StringLength(256)]
        public string Name { get; set; }
    }
}
