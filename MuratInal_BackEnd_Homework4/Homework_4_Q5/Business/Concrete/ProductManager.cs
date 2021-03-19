using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : EfProductDal ,IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public List<Product> GetAll()
        {
            return _productDal.GetList().ToList();
        }

        public List<Product> GetById(int id)
        {
            return _productDal.GetList(p => p.CategoryId == id).ToList();
        }

        public List<Product> GetByName(string name)
        {
            return _productDal.GetList(p => p.ProductName == name).ToList();
        }
    }
}
