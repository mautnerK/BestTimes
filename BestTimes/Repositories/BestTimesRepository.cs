using BestTimes.Data;
using Microsoft.EntityFrameworkCore;

namespace BestTimes.Repositories
{
    public class BestTimesRepository : IBestTimesRepository
    {
        private readonly BestTimesContext db;

        public BestTimesRepository(BestTimesContext db)
        {
            this.db = db;
        }

        public async Task<List<Models.BestTimes>> GetBestTimesAsync()
        {

            return await db.BestTimes.OrderBy(x => x.Time).ToListAsync();
        }

        public async Task SuggestBestTimeAsync(Models.PendingBestTimes bestTime)
        {
            db.PendingBestTimes.Add(bestTime);
            await db.SaveChangesAsync();
        }
    }
}
