using System.Text.Json.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Habitify.Models
{
    public class Habit
    {
        [Key]
        public int HabitId { get; set; }


        [Required]
        public string HabitName { get; set; }


        [ForeignKey("Users")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? Users { get; set; }

    }
}
