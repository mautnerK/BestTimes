using BestTimes.Data;
using BestTimes.Models;
using Microsoft.EntityFrameworkCore;

namespace BestTimes.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BestTimesContext db;

        public AdminRepository(BestTimesContext db)
        {
            this.db = db;
        }
        public async Task<List<Models.BestTimes>> GetBestTimesAsync()
        {
           return await db.BestTimes.OrderBy(x => x.Time).ToListAsync();
          
        }

        public async Task<List<Models.PendingBestTimes>> GetSuggestedTimesAsync()
        {
            return await db.PendingBestTimes.ToListAsync();
        }
        public async Task<Models.BestTimes> GetBestTimeByIdAsync(int i) => await db.BestTimes.FindAsync(i);
        public void AcceptSuggestedTimes(PendingBestTimes pendingBestTime) {
            Models.BestTimes bestTimes = new Models.BestTimes();
            bestTimes.FirstName = pendingBestTime.FirstName;
            bestTimes.LastName = pendingBestTime.LastName;
            bestTimes.Time = pendingBestTime.Time;
            db.BestTimes.Add(bestTimes);
            db.PendingBestTimes.Remove(pendingBestTime);
            db.SaveChanges();
        }

        public async Task<PendingBestTimes> GetSuggestedTimeByIdAsync(int i) => await db.PendingBestTimes.FindAsync(i);
        public void RemoveTime(Models.BestTimes bestTime)
        {
            db.BestTimes.Remove(bestTime);
            db.SaveChanges();
        }

        public void RemoveSuggestedTime(Models.PendingBestTimes pendingTime)
        {
            db.PendingBestTimes.Remove(pendingTime);
            db.SaveChanges();
        }
    }
}
