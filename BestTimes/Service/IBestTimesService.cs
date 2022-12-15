namespace BestTimes.Service
{
    public interface IBestTimesService
    {
        Task<List<Models.BestTimes>> GetBestTimesAsync();
        Task SuggestBestTimeAsync(Models.PendingBestTimes bestTime);
    }
}
