using Core.DataAccess;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService : IBusinessRepository<Category>, IEntityRepository<Category>
    {
       
    }
}
