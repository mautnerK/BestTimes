using System.ComponentModel.DataAnnotations.Schema;

namespace BestTimes.Models
{
    public class AdminLoginInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
