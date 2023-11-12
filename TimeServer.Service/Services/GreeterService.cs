using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using TimeServer.Service;

namespace TimeServer.Service.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly TimeServerDbContext _dbContext;
        public GreeterService(ILogger<GreeterService> logger, TimeServerDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
                _dbContext.LogRequestCurrentTimes.Add(new Repository.Entities.LogRequestCurrentTime() { RequestTimeStampUtc = DateTime.UtcNow });
                _dbContext.SaveChanges();

                var allRequest = _dbContext.LogRequestCurrentTimes.ToList();
                int count = allRequest.Count;
           
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}