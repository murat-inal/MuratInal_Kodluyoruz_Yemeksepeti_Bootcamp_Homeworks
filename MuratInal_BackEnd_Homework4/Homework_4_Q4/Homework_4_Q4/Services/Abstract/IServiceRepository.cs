using Homework_4_Q4.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_Q4.Services
{
    public interface IServiceRepository<T> where T: IEntity, new()
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
