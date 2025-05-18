using InventoryApp.Model;

namespace InventoryApp.Service
{
    public interface IProductService
    {
        Product? GetProduct(int id);
        Product AddProduct(update_product obj);
        Product? UpdateProduct(int id, update_product obj);
        bool DeleteProduct(int id);
    }
}
