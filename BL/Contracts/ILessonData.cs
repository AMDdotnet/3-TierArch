using Model;
using System;
using System.Collections.Generic;

namespace BL.Contracts
{
    public interface ILessonData
    {
        OperationResult<List<Lesson>> GetAll();

        OperationResult Insert(string name, byte units);

        OperationResult Update(Guid id, string name, byte units);
    }
}
