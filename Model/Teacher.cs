using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Model
{
    public class Teacher
    {
        [Required(ErrorMessage = "نام را وارد کن")]
        [MaxLength(10, ErrorMessage = "tool kamtar")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NationalCodeValidation]
        public string NationalCode { get; set; }
        public string[] MobileNumbers { get; set; }
        public int Score { get; set; }
        public int Id { get; set; }

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
