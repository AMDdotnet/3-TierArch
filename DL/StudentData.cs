using Model;
using System;
using System.Collections.Generic;

namespace DL
{
    public class StudentData
    {
        static List<StudentDto> _students = new List<StudentDto>();
        public OperationResult Insert(string firstName, string studentCode)
        {
            try
            {
                _students.Add(new StudentDto
                {
                    Name = firstName,
                    StudentCode = studentCode
                });
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
        public OperationResult<List<StudentDto>> SelectAll()
        {
            try
            {
                return OperationResult<List<StudentDto>>.Success(_students);
            }
            catch (Exception ex)
            {
                return OperationResult<List<StudentDto>>.Failure(ex.Message);
            }
        }
        public OperationResult Select(int id)
        {
            try
            {
                foreach (var student in _students)
                {
                    if (student.Id == id)
                        return OperationResult<StudentDto>.Success(student);
                }
                return OperationResult.Failure("student not found");
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }
        public int SelectStudentId(string studentCode)
        {
            try
            {
                foreach (var student in _students)
                {
                    if (student.StudentCode == studentCode)
                        return student.Id;
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
