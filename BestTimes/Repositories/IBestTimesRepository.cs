namespace BestTimes.Repositories
{
    public interface IBestTimesRepository
    {
        Task<List<Models.BestTimes>> GetBestTimesAsync();
        Task SuggestBestTimeAsync(Models.PendingBestTimes bestTime);
    }
}
