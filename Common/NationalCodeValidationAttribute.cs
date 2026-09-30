using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NationalCodeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var nationalCode = (string)value;
            if (string.IsNullOrEmpty(nationalCode))
            {
                ErrorMessage = "کدملی خالیه";
                return false;
            }
            if (nationalCode.Length != 10)
            {
                ErrorMessage = "کدملی طولش 10 نیست";
                return false;
            }

            return true;
        }
    }
}
