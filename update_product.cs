namespace InventoryApp.Model
{
    public class update_product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
