
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
        string connString = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + Configuration.GetConnectionString("TimeServerDatabase");
        options.UseSqlite("Data Source=" + connString);
    }

    public DbSet<LogRequestCurrentTime> LogRequestCurrentTimes { get; set; }

}