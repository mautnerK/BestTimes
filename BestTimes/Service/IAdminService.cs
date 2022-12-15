using BestTimes.Models;

namespace BestTimes.Service
{
    public interface IAdminService
    {
        Task<List<Models.BestTimes>> GetBestTimesAsync();
        Task<List<Models.PendingBestTimes>> GetSuggestedTimesAsync();
        Task<Models.BestTimes> GetBestTimeByIdAsync(int i);
        Task<Models.PendingBestTimes> GetSuggestedTimeByIdAsync(int i);
        void AcceptSuggestedTimes(PendingBestTimes pendingBestTime);
        void RemoveTime(Models.BestTimes bestTime);
        void RemoveSuggestedTime(Models.PendingBestTimes suggestedTime);
    }
}
