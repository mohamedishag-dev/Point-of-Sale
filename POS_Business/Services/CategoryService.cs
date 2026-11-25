using POS_Business.DTOs.Products;
using POS_Business.Security;
using POS_Business.Servicies;
using POS_DataAccess.Interfaces;
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

        public DataTable GetAllUnits()
        {
            Session.Require(Perm.CategoriesManage);

            return _repo.GetAllUnits();

        }

        public DataTable GetAllCategories()
        {
            Session.Require(Perm.CategoriesManage);

            return _repo.GetAllCategories();

        }

        public bool IsExists(int categoryID)
        {
            return _repo.IsExists(categoryID);
        }

        public bool Deactivate(int categoryID)
        {
            Session.Require(Perm.CategoriesManage);

            return _repo.Deactivate(categoryID);

        }

        public UnitDto GetByUnitName(string UnitName)
        {
            Unit unit = _repo.GetByUnitName(UnitName);

            if (unit == null) return null;

            UnitDto unitDto = new UnitDto
            {
                UnitID = unit.UnitID,
                UnitName = unit.UnitName
            };

            return unitDto;

        }

        public bool AddCategory(CategoryDto categoryDto)
        {
            Session.Require(Perm.CategoriesManage);

            Category category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description
            };

            category.CategoryID = _repo.AddCategory(category);
            return (category.CategoryID != -1);

        }

        public CategoryDto GetByCategoryID(int CategoryID)
        {
            Category category = _repo.GetByCategoryID(CategoryID);

            if (category == null) return null;

            CategoryDto categoryDto = new CategoryDto
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            return categoryDto;

        }

        public CategoryDto GetByCategoryName(string CategoryName)
        {
            Category category = _repo.GetByCategoryName(CategoryName);

            if (category == null) return null;

            return new CategoryDto
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive
            };

        }

        public bool UpdateCategory(CategoryDto categoryDto)
        {
            Session.Require(Perm.CategoriesManage);

            Category category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description
            };
            return _repo.UpdateCategory(category);

        }


    }
}
