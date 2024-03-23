namespace Habitify.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties for one-to-many relationships
        public ICollection<Habit> Habits { get; set; }

        public User()
        {
            Habits = new List<Habit>();
        }
    }
}
