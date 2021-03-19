using Hotels.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotels.API.Workers
{
    public class RoomWorkerService : BackgroundService
    {
        private ILogger<RoomWorkerService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private HotelApiDbContext _dbContext;

        public RoomWorkerService(ILogger<RoomWorkerService> logger, IServiceScopeFactory scopeFactory, HotelApiDbContext dbContext)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _dbContext = dbContext;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<HotelApiDbContext>();

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
                    _dbContext = scope.ServiceProvider.GetRequiredService<HotelApiDbContext>();
                }
                var migratingRecords = await _dbContext.Rooms.Where(room => !room.IsMigrate).ToListAsync();

                foreach (var record in migratingRecords)
                {
                    // do work

                    record.IsMigrate = true;
                }

                if (_dbContext.ChangeTracker.HasChanges())
                {
                    await _dbContext.SaveChangesAsync();
                }

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation("Worker Running");
            

            await Task.Delay(3000, stoppingToken);
        }
    }
}
}
