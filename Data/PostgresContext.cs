using HowToMakeItAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HowToMakeItAPI.Data;

public class PostgresContext : DbContext
{
    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Step> Steps { get; set; }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new TutorialEntityTypeConfiguration().Configure(modelBuilder.Entity<Tutorial>());
        new StepEntityTypeConfiguration().Configure(modelBuilder.Entity<Step>());
    }
}