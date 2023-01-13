namespace virtualReality.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; } // HASH!
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
