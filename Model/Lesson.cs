using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Model
{
    public class Lesson
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty..")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 char.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Number of units cannot be empty..")]
        [Range(1,4, ErrorMessage = "Unit must be between 1 and 4 numbers.")]
        public byte Units { get; set; }
        public string ErrorMessage {  get; private set; }
        public bool IsValid
        {
            get
            {
                var validationContext = new ValidationContext(this);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(this, validationContext, results, true))
                {
                    ErrorMessage = string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage));
                    return false;
                }
                return true;
            }
        }

        public Lesson(string name, byte units)
        {
            Id = Guid.NewGuid();
            Name = name;
            Units = units;
        }
    }
}
