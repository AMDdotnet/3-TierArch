using DL;
using Model;

namespace BL
{
    public class BimarService
    {
        public OperationResult Insert(string firstName, string lastName, string nationalCode)
        {
            var result = ValidateInputData(firstName, lastName, nationalCode);
            if (!result.IsSuccess)
            {
                return result;
            }

            var bimar = new BimarData();
            var isDuplicate = bimar.SelectBimarId(nationalCode) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate national code");
            }

            bool ok = bimar.Insert(firstName, lastName, nationalCode);
            if (ok)
                return OperationResult.Success();
            else
                return OperationResult.Failure("error in submit data");
        }

        private OperationResult ValidateInputData(string firstName, string lastName, string nationalCode)
        {
            if (string.IsNullOrEmpty(firstName))
                return OperationResult.Failure("enter first name");
            if (string.IsNullOrEmpty(lastName))
                return OperationResult.Failure("enter lastName");
            if (string.IsNullOrEmpty(nationalCode))
                return OperationResult.Failure("enter nationalCode");

            return OperationResult.Success();
        }
    }
}
