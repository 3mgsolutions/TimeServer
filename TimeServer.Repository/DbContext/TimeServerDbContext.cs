
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TimeServer.Repository.Entities;

public class TimeServerDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TimeServerDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("TimeServerDatabase"));
    }

    public DbSet<LogRequestCurrentTime> LogRequestCurrentTimes { get; set; }

}