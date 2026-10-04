using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface ITeacherService
    {
        OperationResult Insert(string firstName, string mobile);

        OperationResult<List<Teacher>> SelectAll();
    }
}
