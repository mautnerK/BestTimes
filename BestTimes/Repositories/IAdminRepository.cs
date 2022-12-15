using BestTimes.Models;

namespace BestTimes.Repositories
{
    public interface IAdminRepository
    {
        Task<List<Models.BestTimes>> GetBestTimesAsync();
        Task<List<Models.PendingBestTimes>> GetSuggestedTimesAsync();
        Task<Models.PendingBestTimes> GetSuggestedTimeById(int i); 
        void AcceptSuggestedTimes(PendingBestTimes pendingBestTime);

    }
}
