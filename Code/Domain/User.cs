namespace Domain
{
    public class User
    {
        public User()
        {
            Role = null;
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public object Role { get; set; }
    }
}