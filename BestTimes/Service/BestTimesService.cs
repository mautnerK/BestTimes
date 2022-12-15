using BestTimes.Models;
using BestTimes.Repositories;

namespace BestTimes.Service
{
    public class BestTimesService : IBestTimesService
    {
        private IBestTimesRepository repo;
        public BestTimesService(IBestTimesRepository repo)
        {
            this.repo = repo;
        }
        public Task<List<Models.BestTimes>> GetBestTimesAsync()
        {
            return repo.GetBestTimesAsync();
        }

        public Task SuggestBestTimeAsync(PendingBestTimes bestTime)
        {
           return repo.SuggestBestTimeAsync(bestTime);
        }
    }
}
