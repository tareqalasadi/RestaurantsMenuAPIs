namespace RestaurantsMenu.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string DescEn { get; set; } = string.Empty;
        public string DescAr { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
    }
}
