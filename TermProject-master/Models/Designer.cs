using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class Designer
    {
        [Required]
        [Display(Name = "Designer ID")]
        public int DesignerId { get; set; }

        [Required]
        [Column("First Name")]
        [Display(Name = "First Name")]
        [StringLength(35, ErrorMessage = "Please enter your first name.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "Please enter your last name.")]
        [Column("Last Name")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email.")]
        public string? Email { get; set; }
    }
}
