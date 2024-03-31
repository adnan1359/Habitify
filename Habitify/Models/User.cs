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



        // Navigation properties for one-to-many relationships
        public ICollection<Habit> Habits { get; set; }
        //public int HabitId { get; set; }

        public User()
        {
            Habits = new List<Habit>();
        }

    }
}
