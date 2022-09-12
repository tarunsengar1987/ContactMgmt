using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContantMgmt.Models
{
    public class Contact
    {
        public int contactID { get; set; }

        [Display(Name = "Contact Name")]
        [Required(ErrorMessage = "Contact Name is required.")]
        [MinLength(6, ErrorMessage = "Contact Name is required of min. 6 chars.")]
        public string contactName { get; set; }

        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Contact No is required.")]
        [MinLength(9, ErrorMessage = "Contact No is required of min. 9 chars.")]
        public string contactNo { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Valid Email Address is required.")]
        public string contactEmail { get; set; }
    }
}
