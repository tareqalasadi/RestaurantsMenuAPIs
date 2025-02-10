namespace RestaurantsMenu.Models
{
     public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
