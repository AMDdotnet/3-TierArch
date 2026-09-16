using DL;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class TeacherService
    {
        public OperationResult Insert(string firstName, string mobile)
        {
            var Teacher = new TeacherDL();
            var result = ValidateInputData(firstName, mobile);
            if (!result.IsSuccess)
            {
                return result;
            }
            var isDuplicate = Teacher.SelectTeacherId(mobile) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate mobile");
            }

            return Teacher.Insert(firstName, mobile);
        }
        public OperationResult<List<Teacher>> SelectAll()
        {
            var teacher = new TeacherDL();
            return teacher.SelectAll();
        }
        private OperationResult ValidateInputData(string firstName, string mobile)
        {
            if (string.IsNullOrEmpty(firstName))
                return OperationResult.Failure("enter first name");
            if (string.IsNullOrEmpty(mobile))
                return OperationResult.Failure("enter mobile");

            return OperationResult.Success();
        }
    }

}
