namespace Web_CaPhee2_api.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ? Detail {  get; set; }
        public string? ImageUrl {  get; set; }
        public decimal? Price { get; set; }
        public bool IsTrendingProduct { get; set; } 
    }
}
