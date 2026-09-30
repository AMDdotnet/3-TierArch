using Common;
using Common.Constants;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class TeacherDL
    {
        ILogger _logger;
        public TeacherDL(ILogger logger)
        {
            _logger = logger;
        }
        static List<Teacher> _teachers = new List<Teacher>()
        {
            new Teacher
            {
                Id = 1,
                MobileNumbers = new string[]{"091333","0993332"},
                FirstName = "ali",
                LastName = "alavi",
                Score = 16
            },
            new Teacher{Id = 2,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 11},
            new Teacher{Id = 3,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 12},
            new Teacher{Id = 4,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 11},
            new Teacher{Id = 5,
                MobileNumbers = new string[]{"091311","09442","0996666"},FirstName = "maryam",LastName = "razavi",Score = 12},
            new Teacher{Id = 6,
                MobileNumbers = new string[]{"091333"},FirstName = "nazanin",LastName = "nazi",Score = 17},
            new Teacher{Id = 7,FirstName = "pedram"},
                     new Teacher
            {
                Id = 8,
                MobileNumbers = new string[]{"091333","0993332"},
                FirstName = "ali",
                LastName = "alavi",
                Score = 15
            },
            new Teacher{Id = 9,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 11},
            new Teacher{Id = 15,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 12},
            new Teacher{Id = 15,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 11},
            new Teacher{Id = 12,
                MobileNumbers = new string[]{"091311","09442","0996666"},FirstName = "maryam",LastName = "razavi",Score = 12},
            new Teacher{Id = 13,
                MobileNumbers = new string[]{"091333"},FirstName = "nazanin",LastName = "nazi",Score = 17},
            new Teacher{Id = 14,FirstName = "pedram"},
               new Teacher{Id = 7,FirstName = "pedram"},
                     new Teacher
            {
                Id = 8,
                MobileNumbers = new string[]{"091333","0993332"},
                FirstName = "ali",
                LastName = "alavi",
                Score = 15
            },
            new Teacher{Id = 15,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "rezaie",Score = 11},
            new Teacher{Id = 16,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "hasani",Score = 12},
            new Teacher{Id = 17,
                MobileNumbers = new string[]{"091333"},FirstName = "reza",LastName = "ahmadi",Score = 11},
            new Teacher{Id = 18,
                MobileNumbers = new string[]{"091311","09442","0996666"},FirstName = "maryam",LastName = "razavi",Score = 12},
            new Teacher{Id = 19,
                MobileNumbers = new string[]{"091333"},FirstName = "nazanin",LastName = "nazi",Score = 17},
            new Teacher{Id = 20,FirstName = "pedram"}
        };
        public OperationResult Insert(string firstName, string mobile)
        {
            try
            {
                _teachers.Add(new Teacher
                {
                    FirstName = firstName,
                    MobileNumbers = new string[] { mobile }
                });
                return OperationResult.Success();
            }
            catch (Exception ex)
            {

                return OperationResult.Failure(ex.Message);
            }
        }
        public OperationResult<List<Teacher>> SelectAll()
        {
            _logger.Write("TeacherDL:begin select teacher");

            try
            {
                var ts = _teachers.ToList();

                //foreach (var t in ts)
                //{
                //    t.Id = ts.IndexOf(t) + 1;
                //}
                _logger.Write("TeacherDL:begin select teacher");
                return OperationResult<List<Teacher>>.Success(ts.ToList());
            }
            catch (Exception ex)
            {
                _logger.Write("TeacherDL:error select teacher-" + ex.Message);
                var success = MessageConstants.SuccessMessage;
                return OperationResult<List<Teacher>>.Failure(MessageConstants.SystemError);
            }

        }
        public OperationResult Select(int id)
        {
            try
            {
                foreach (var teacher in _teachers)
                {
                    if (teacher.Id == id)
                        return OperationResult<Teacher>.Success(teacher);
                }
                return OperationResult.Failure("teacher not found");
            }
            catch (Exception ex)
            {
                return OperationResult<List<Teacher>>.Failure(MessageConstants.SystemError);
            }
        }
        public int SelectTeacherId(string mobile)
        {
            try
            {
                foreach (var teacher in _teachers)
                {
                    //if (teacher.Mobile == mobile)
                    //    return teacher.Id;
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
