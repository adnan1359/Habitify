using System.ComponentModel.DataAnnotations;

namespace Habitify.Models
{
    public class Habit
    {
        [Key]
        public int HabitId { get; set; }
        public int UserId { get; set; }  // Foreign key
        public int CategoryId { get; set; }  // Foreign key
        public string HabitName { get; set; }

        // Navigation properties for one-to-many relationships
        public User User { get; set; }
        public Category Category { get; set; }


    }
}
