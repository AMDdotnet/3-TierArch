using BL.Contracts;
using Common;
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
        private readonly ILogger _logger;
        public LessonService(ILessonData lessonData, ILogger logger)
        {
            _lessonData = lessonData;
            _logger = logger;
        }

        public OperationResult<List<Lesson>> GetAll()
        {
            _logger.Write("all lessons Selected.");
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
