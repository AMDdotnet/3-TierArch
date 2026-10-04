using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface ITeacherData
    {
        OperationResult Insert(string firstName, string mobile);

        OperationResult<List<Teacher>> SelectAll();

        OperationResult Select(int id);

        int SelectTeacherId(string mobile);
    }
}
