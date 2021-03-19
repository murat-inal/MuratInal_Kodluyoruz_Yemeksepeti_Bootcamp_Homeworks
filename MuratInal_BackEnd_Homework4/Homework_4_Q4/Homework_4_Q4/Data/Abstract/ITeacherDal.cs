using Homework_4_Q4.Core.DataAccess;
using Homework_4_Q4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Data.Abstract
{
    public interface ITeacherDal : IEntityRepository<Teacher>
    {
    }
}
