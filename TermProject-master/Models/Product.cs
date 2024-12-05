using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TermProject.Models
{
    public class Product
    {
        [Display(Name = "Season Id")]
        public string SeasonId { get; set; } = string.Empty;
        [ValidateNever]
        public Season Season { get; set; } = null!;

        public int ProductId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please enter a name.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string Name { get; set; } = string.Empty;

        [Range(1979,3000)]
        [Required(ErrorMessage = "Please enter a year.")]
        public int? Year { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter a clothing type.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string Type { get; set; } = string.Empty;
    }
}
