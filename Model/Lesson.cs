using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Attributes;

namespace Model
{
    public class Lesson : IDataErrorInfo
    {
        [Required]
        [DgvDisplay("شناسه")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty..")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 char.")]
        [DgvDisplay("نام درس")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Number of units cannot be empty..")]
        [Range(1,4, ErrorMessage = "Unit must be between 1 and 4 numbers.")]
        [DgvDisplay("تعداد واحد")]
        public byte Units { get; set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(this) { MemberName = columnName };

                return columnName == nameof(Name) && !Validator.TryValidateProperty(Name, context, results) ||
                    columnName == nameof(Units) && !Validator.TryValidateProperty(Units, context, results)
                    ? results.Select(x => x.ErrorMessage).FirstOrDefault()
                    : null;
            }
        }

        public Lesson(string name, byte units)
        {
            Id = Guid.NewGuid();
            Name = name;
            Units = units;
        }

        public string ErrorMessage { get; private set; }
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
    }
}
