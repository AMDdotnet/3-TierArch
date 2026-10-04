using BL.Contracts;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class StudentService
    {
        private readonly IStudentData _studentData;

        public StudentService(IStudentData studentData) => _studentData = studentData;

        public OperationResult Insert(string firstName, string studentCode)
        {
            var result = ValidateInputData(firstName, studentCode);
            if (!result.IsSuccess)
            {
                return result;
            }
            var isDuplicate = _studentData.SelectStudentId(studentCode) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate student code");
            }

            return _studentData.Insert(firstName, studentCode);
        }
        public OperationResult<List<StudentDto>> SelectAll()
        {
            return _studentData.SelectAll();
        }
        private OperationResult ValidateInputData(string firstName, string studentCode)
        {
            if (string.IsNullOrEmpty(firstName))
                return OperationResult.Failure("enter first name");
            if (string.IsNullOrEmpty(studentCode))
                return OperationResult.Failure("enter student code");

            return OperationResult.Success();
        }
    }
}
