using BL.Contracts;
using Model;

namespace BL
{
    public class BimarService : IBimarService
    {
        private readonly IBimarData _bimarData;

        public BimarService(IBimarData bimarData) => _bimarData = bimarData;

        public OperationResult Insert(string firstName, string lastName, string nationalCode)
        {
            var result = ValidateInputData(firstName, lastName, nationalCode);
            if (!result.IsSuccess)
            {
                return result;
            }

            var isDuplicate = _bimarData.SelectBimarId(nationalCode) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate national code");
            }

            bool ok = _bimarData.Insert(firstName, lastName, nationalCode);
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
