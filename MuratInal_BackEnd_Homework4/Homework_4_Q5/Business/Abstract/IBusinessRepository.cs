using Core.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBusinessRepository<T> where T : IEntity, new()
    {
        List<T> GetAll();
        List<T> GetById(int id);
        List<T> GetByName(string name);

    }
}
