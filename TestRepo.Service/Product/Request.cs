namespace TetPee.Service.Product;

public class Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid SellerId { get; set; }
        public List<Guid>? CategoryIds { get; set; }
    }
}