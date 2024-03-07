using DBProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCAppWithEF.ViewModels
{
    public class EditCustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Last First is required")]
        [StringLength(40)]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(40)]
        public string LastName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
