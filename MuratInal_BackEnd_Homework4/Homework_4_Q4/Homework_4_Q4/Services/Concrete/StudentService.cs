using Homework_4_Q4.Core.DataAccess;
using Homework_4_Q4.Data;
using Homework_4_Q4.Data.Abstract;
using Homework_4_Q4.Data.Concrete;
using Homework_4_Q4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Services
{
    public class StudentService : EfStudentDal, IStudentService
    {
        private IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public Student GetById(int id)
        {
            return _studentDal.Get(s => s.StudentId == id);
        }

        public List<Student> GetAll()
        {
            return _studentDal.GetList().ToList();
        }
    }
}
