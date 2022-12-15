using System.ComponentModel.DataAnnotations.Schema;

namespace BestTimes.Models
{
    public class BestTimes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan Time { get; set; }
    }
}
