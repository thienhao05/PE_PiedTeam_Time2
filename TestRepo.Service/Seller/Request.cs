namespace TetPee.Service.Seller;

public class Request
{
    public class CreateSellerRequest : User.Request.UserRequest
    {
        public required string TaxCode { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyAddress { get; set; }
    }
}