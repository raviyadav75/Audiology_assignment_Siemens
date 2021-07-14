namespace JewelryEstimate_Assignment.Entities
{
    public class AppUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsPrivileged { get; set; }
    }
}
