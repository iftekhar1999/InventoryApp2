using InventoryApp.Model;

namespace InventoryApp.Service
{
    public interface ICategoryService
    {
        Category? GetCategory(int id);
        Category AddCategory(Category obj);
        Category? UpdateCategory(int id, update_category obj);
        bool DeleteCategory(int id);
    }
}
