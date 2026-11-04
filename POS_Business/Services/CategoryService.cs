using POS_Business.Servicies;
using POS_DataAccess.interfaceis;
using POS_DataAccess.Models;
using System.Data;

namespace POS_Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repository)
        {
            _repo = repository;
        }

        public DataTable GetAll()
        {
            return _repo.GetAll();

        }

        public bool Add(Category category)
        {
            category.CategoryID = _repo.Add(category);
            return (category.CategoryID != -1);

        }

        public bool Deactivate(int categoryID)
        {
            return _repo.Deactivate(categoryID);

        }

        public bool Update(Category category)
        {
            return _repo.Update(category);
        
        }

        public bool IsExists(int categoryID)
        {
            return _repo.IsExists(categoryID);
        }

    }
}
