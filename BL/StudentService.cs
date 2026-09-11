using DL;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class StudentService
    {
        public OperationResult Insert(string firstName, string studentCode)
        {
            var student = new StudentData();
            var result = ValidateInputData(firstName, studentCode);
            if (!result.IsSuccess)
            {
                return result;
            }
            var isDuplicate = student.SelectStudentId(studentCode) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate student code");
            }

            return student.Insert(firstName, studentCode);
        }
        public OperationResult<List<StudentDto>> SelectAll()
        {
            var student = new StudentData();
            return student.SelectAll();
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
