using BL.Contracts;
using Common;
using Model;
using System.Collections.Generic;

namespace BL
{
    public class TeacherService
    {
        ILogger _logger;
        private readonly ITeacherData _teacherData;
        public TeacherService(ILogger logger, ITeacherData teacherData)
        {
            _logger = logger;
            _teacherData = teacherData;
        }
        public OperationResult Insert(string firstName, string mobile)
        {
            var result = ValidateInputData(firstName, mobile);
            if (!result.IsSuccess)
            {
                return result;
            }
            var isDuplicate = _teacherData.SelectTeacherId(mobile) > 0;
            if (isDuplicate)
            {
                return OperationResult.Failure("duplicate mobile");
            }

            return _teacherData.Insert(firstName, mobile);
        }
        public OperationResult<List<Teacher>> SelectAll()
        {

            //FileLogger.Write("TeacherService:begin select teacher");
            _logger.Write("TeacherService:begin select teacher");
            var teachers = _teacherData.SelectAll();
            _logger.Write("TeacherService:end select teacher");
            return teachers;
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
