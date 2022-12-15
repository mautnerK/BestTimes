using System;
using System.Collections.Generic;
using BestTimes.Models;
using Microsoft.EntityFrameworkCore;

namespace BestTimes.Data;

public partial class BestTimesContext : DbContext
{
    public BestTimesContext()
    {
    }
    public DbSet<BestTimes.Models.BestTimes> BestTimes { get; set; }
    public DbSet<PendingBestTimes> PendingBestTimes { get; set; }
    public DbSet<AdminLoginInfo> AdminLoginInfo { get; set; }

    public BestTimesContext(DbContextOptions<BestTimesContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Data Source=.;Database=BestTimes;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
