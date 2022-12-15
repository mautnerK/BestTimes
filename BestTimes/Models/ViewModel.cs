using NuGet.DependencyResolver;

namespace BestTimes.Models
{
    public class ViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Time { get; set; }
        public IEnumerable<BestTimes> BestTimes { get; set; }
        public IEnumerable<PendingBestTimes> PendingBestTimes { get; set; }
    }
}
