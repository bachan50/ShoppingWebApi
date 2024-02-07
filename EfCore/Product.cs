using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebApi.EfCore
{
    [Table("product")]
    public class Product
    {
        [Key,Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Size {  get; set; }
        public decimal price { get; set; }
    }
}
