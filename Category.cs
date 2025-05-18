using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
