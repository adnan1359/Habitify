using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Habitify.Models
{
    public class Progress
    {

        [Key]
        public int ProgressId { get; set; }


        [Required]
        public string DateUpdated { get; set; } = DateTime.UtcNow.ToString();



        [Required]
        public string Status { get; set; } = "pending";



        [ForeignKey("User")]

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }



        public int HabitIdentity { get; set; }

    }
}
