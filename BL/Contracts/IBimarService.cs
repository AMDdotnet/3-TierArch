using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IBimarService
    {
        OperationResult Insert(string firstName, string lastName, string nationalCode);
    }
}
