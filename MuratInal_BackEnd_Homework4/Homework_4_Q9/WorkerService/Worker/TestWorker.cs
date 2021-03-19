using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Context;

namespace WorkerService.Worker
{
    public class TestWorker : BackgroundService
    {
        private ILogger<TestWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private WorkerServiceDbContext _dbContext;

        public TestWorker(ILogger<TestWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<WorkerServiceDbContext>();
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_dbContext == null)
                {
                    var scope = _scopeFactory.CreateScope();
                    _dbContext = scope.ServiceProvider.GetRequiredService<WorkerServiceDbContext>();
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var loggedOutUsers = await _dbContext.Users
                    .Where(user => user.IsOnline &&
                                   user.EndLoginTime <= DateTime.Now).ToListAsync();

                foreach (var user in loggedOutUsers)
                {
                    user.IsOnline = false;
                    _logger.LogInformation("User {0} timed out",user.UserName);
                }

                if (_dbContext.ChangeTracker.HasChanges())
                {
                    await _dbContext.SaveChangesAsync();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
