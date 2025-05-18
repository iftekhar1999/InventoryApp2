using InventoryApp.Model;

namespace InventoryApp.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categoryList;
        public CategoryService()
        {
            _categoryList = new List<Category>()
            {
                new Category(){
                Name = "",
                }
            };
        }

        public Category? GetCategory(int id)
        {
            return _categoryList.FirstOrDefault(category => category.Id == id);
        }

        public Category AddCategory(update_category obj)
        {
            var addcategory = new Category()
            {
                Id = obj.Id,
                Name = obj.Name,
            };

            _categoryList.Add(addcategory);

            return addcategory;
        }

        public Category? UpdateCategory(int id, update_category obj)
        {
            var categoryIndex = _categoryList.FindIndex(index => index.Id == id);
            if (categoryIndex > 0)
            {
                var category = _categoryList[categoryIndex];

                category.Name = obj.Name;

                _categoryList[categoryIndex] = category;

                return category;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteCategory(int id)
        {
            var categoryIndex = _categoryList.FindIndex(index => index.Id == id);
            if (categoryIndex >= 0)
            {
                _categoryList.RemoveAt(categoryIndex);
            }
            return categoryIndex >= 0;
        }
    }
}
