using TimeServer.Service.Inerface;

namespace TimeServer.Service.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTimeUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
