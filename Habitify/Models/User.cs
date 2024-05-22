using System.ComponentModel.DataAnnotations;

namespace Habitify.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }



        public ICollection<Habit> Habits { get; set; }
        public ICollection<Progress> Progresses { get; set; }

        public User()
        {
            Habits = new List<Habit>();
            Progresses = new List<Progress>();
        }

    }
}
