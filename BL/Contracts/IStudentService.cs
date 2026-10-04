using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IStudentService
    {
        OperationResult Insert(string firstName, string studentCode);

        OperationResult<List<StudentDto>> SelectAll();
    }
}
