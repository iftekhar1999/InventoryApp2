using InventoryApp.Model;
using static InventoryApp.Service.ProductService;

namespace InventoryApp.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _productList;
        public ProductService()
        {
            _productList = new List<Product>()
            {
                new Product(){
                Name = "Test",
                CategoryId = 0, 
                }
            };
        }
        
        public Product? GetProduct(int id)
        {
            return _productList.FirstOrDefault(product => product.Id == id);
        }

        public Product AddProduct(update_product obj)
        {
            var addproduct= new Product()
            {
                Name = obj.Name,
                CategoryId = obj.CategoryId,
            };

            _productList.Add(addproduct);

            return addproduct;
        }

        public Product? UpdateProduct(int id, update_product obj)
        {
            var productIndex = _productList.FindIndex(index => index.Id == id);

            if (productIndex > 0)
            {
                var product = _productList[productIndex];

                product.Name = obj.Name;
                product.CategoryId = obj.CategoryId;

                _productList[productIndex] = product;

                return product;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteProduct(int id)
        {
            var productIndex = _productList.FindIndex(index => index.Id == id);
            if (productIndex >= 0)
            {
                _productList.RemoveAt(productIndex);
            }
            return productIndex >= 0;
        }
    }
}