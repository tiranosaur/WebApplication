using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class User
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Column("Email")]
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Column("Age")] 
        public int Age { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Name))
            {
                errors.Add(new ValidationResult("Name is required!"));
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                errors.Add(new ValidationResult("Email is required!"));
            }

            return errors;
        }
    }
}