using BestTimes.Models;
using BestTimes.Repositories;

namespace BestTimes.Service
{
    public class AdminService : IAdminService
    {
        private IAdminRepository repo;
        public AdminService(IAdminRepository repo)
        {
            this.repo = repo;
        }
        public void AcceptSuggestedTimes(PendingBestTimes pendingBestTime)
        {
            repo.AcceptSuggestedTimes(pendingBestTime);
        }

        public Task<Models.BestTimes> GetBestTimeByIdAsync(int i)
        {
            return repo.GetBestTimeByIdAsync(i);
        }

        public Task<List<Models.BestTimes>> GetBestTimesAsync()
        {
            return repo.GetBestTimesAsync();
        }

        public Task<PendingBestTimes> GetSuggestedTimeByIdAsync(int i)
        {
            return repo.GetSuggestedTimeByIdAsync(i);
        }

        public Task<List<PendingBestTimes>> GetSuggestedTimesAsync()
        {
            return repo.GetSuggestedTimesAsync();
        }

        public void RemoveSuggestedTime(PendingBestTimes suggestedTime)
        {
            repo.RemoveSuggestedTime(suggestedTime);
        }

        public void RemoveTime(Models.BestTimes bestTime)
        {
           repo.RemoveTime(bestTime);
        }
    }
}
