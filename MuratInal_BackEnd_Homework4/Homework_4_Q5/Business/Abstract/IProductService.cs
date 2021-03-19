using Core.DataAccess;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService : IBusinessRepository<Product>, IEntityRepository<Product>
    {
        
    }
}
