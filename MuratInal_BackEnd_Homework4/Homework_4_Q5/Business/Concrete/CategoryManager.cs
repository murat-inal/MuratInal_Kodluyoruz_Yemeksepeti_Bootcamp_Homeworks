using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryManager : EfCategoryDal, ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public List<Category> GetAll()
        {
            return _categoryDal.GetList().ToList();
        }

        public List<Category> GetById(int id)
        {
            return _categoryDal.GetList(c => c.CategoryId == id).ToList();
        }

        public List<Category> GetByName(string name)
        {
            return _categoryDal.GetList(c => c.CategoryName == name).ToList();
        }
    }
}

