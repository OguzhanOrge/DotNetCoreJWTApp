namespace JWTCQRSProject.Api.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definations { get; set; }
        public List<Product>? Products { get; set; }
    }
}
