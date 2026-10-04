using Model;
using System.Collections.Generic;

namespace BL.Contracts
{
    public interface IStudentData
    {
        OperationResult Insert(string firstName, string studentCode);

        OperationResult<List<StudentDto>> SelectAll();

        OperationResult Select(int id);

        int SelectStudentId(string studentCode);
    }
}
