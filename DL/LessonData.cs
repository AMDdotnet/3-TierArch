using BL.Contracts;
using Common.Constants;
using Model;
using System;
using System.Collections.Generic;
namespace DL
{
    public class LessonData : ILessonData
    {
        List<Lesson> _lessons = new List<Lesson>()
        {
            new Lesson("Math", 3),
            new Lesson("Physics", 2),
            new Lesson("Chemistry", 3),
            new Lesson("Programming", 4),
            new Lesson("Network", 3)
        };

        public OperationResult<List<Lesson>> GetAll()
        {
            return _lessons.Count > 0
                ? new OperationResult<List<Lesson>>
                {
                    IsSuccess = true,
                    Message = MessageConstants.SuccessMessage,
                    Data = _lessons
                }
                : new OperationResult<List<Lesson>>
                {
                    IsSuccess = true,
                    Message = MessageConstants.NotFound
                };
        }

        public OperationResult Insert(string name, byte units)
        {
            var newLesson = new Lesson(name, units);
            _lessons.Add(newLesson);
            return new OperationResult
            {
                IsSuccess = true,
                Message = MessageConstants.SuccessMessage
            };
        }

        public OperationResult Update(Guid id, string name, byte units)
        {
            var Lesson = _lessons.Find(x => x.Id == id);
            if (Lesson == null)
                return new OperationResult { IsSuccess = false, Message = MessageConstants.NotFound };

            var newLesson = new Lesson(name, units);
            newLesson.Id = Lesson.Id;

            _lessons.Remove(Lesson);
            _lessons.Add(newLesson);
            return new OperationResult
            {
                IsSuccess = true,
                Message = MessageConstants.SuccessMessage
            };
        }
    }
}
