using System.ComponentModel.DataAnnotations;

namespace Habitify.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<Habit> Habits { get; set; }

        public Category()
        {
            Habits = new List<Habit>();
        }
    }
}
