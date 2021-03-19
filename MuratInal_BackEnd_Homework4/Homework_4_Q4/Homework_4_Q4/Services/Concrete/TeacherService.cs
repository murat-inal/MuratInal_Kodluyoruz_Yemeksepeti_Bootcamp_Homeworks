using Homework_4_Q4.Core.DataAccess;
using Homework_4_Q4.Data;
using Homework_4_Q4.Data.Abstract;
using Homework_4_Q4.Data.Concrete;
using Homework_4_Q4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Services.Concrete
{
    public class TeacherService : EfTeacherDal, ITeacherService
    {
        private ITeacherDal _teacherDal;

        public TeacherService(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }
        public Teacher GetById(int id)
        {
            return _teacherDal.Get(t => t.TeacherId == id);
        }

        public List<Teacher> GetAll()
        {
            return _teacherDal.GetList().ToList();
        }
    }
}
