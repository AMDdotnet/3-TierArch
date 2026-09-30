using Common;
using DL;
using Model;
using System;
using System.Collections.Generic;

namespace BL
{
    public class TeacherService
    {
        ILogger _logger;
        public TeacherService(ILogger logger)
        {
            _logger = logger;
        }
        public OperationResult Insert(string firstName, string mobile)
        {
            var Teacher = new TeacherDL(_logger);
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

            var teacher = new TeacherDL(_logger);
            //FileLogger.Write("TeacherService:begin select teacher");
            _logger.Write("TeacherService:begin select teacher");
            var teachers = teacher.SelectAll();
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
