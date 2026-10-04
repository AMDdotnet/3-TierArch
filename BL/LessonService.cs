using BL.Contracts;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LessonService : ILessonService
    {
        private readonly ILessonData _lessonData;
        public LessonService(ILessonData lessonData)
        {
            _lessonData = lessonData;
        }

        public OperationResult<List<Lesson>> GetAll()
        {
            return _lessonData.GetAll();
        }

        public OperationResult Insert(string name, byte units)
        {
            return _lessonData.Insert(name, units);
        }

        public OperationResult Update(Guid id, string name, byte units)
        {
            return _lessonData.Update(id, name, units);
        }
    }
}
