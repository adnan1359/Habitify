using System.ComponentModel.DataAnnotations;

namespace Habitify.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public ICollection<Habit> Habits { get; set; }

        public User()
        {
            Habits = new List<Habit>();
        }

    }
}
