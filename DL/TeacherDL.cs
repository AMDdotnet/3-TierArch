using Model;
using System;
using System.Collections.Generic;

namespace DL
{
    public class TeacherDL
    {
        static List<Teacher> _teachers = new List<Teacher>();
        public OperationResult Insert(string firstName, string mobile)
        {
            try
            {
                _teachers.Add(new Teacher
                {
                    Name = firstName,
                    Mobile = mobile
                });
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
        public OperationResult<List<Teacher>> SelectAll()
        {
            try
            {
                return OperationResult<List<Teacher>>.Success(_teachers);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Teacher>>.Failure(ex.Message);
            }
        }
        public OperationResult Select(int id)
        {
            try
            {
                foreach (var teacher in _teachers)
                {
                    if (teacher.Id == id)
                        return OperationResult<Teacher>.Success(teacher);
                }
                return OperationResult.Failure("teacher not found");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
        public int SelectTeacherId(string mobile)
        {
            try
            {
                foreach (var teacher in _teachers)
                {
                    if (teacher.Mobile == mobile)
                        return teacher.Id;
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }
    }
}
