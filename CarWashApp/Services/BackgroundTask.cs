using Microsoft.EntityFrameworkCore;

namespace CarWashApp.Services
{
    public class BackgroundTask : IHostedService, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private Timer? timer;

        public BackgroundTask(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var currentTime = DateTime.Now;
                var reservations = await context.Reservations.Where(x => x.ReservationDateTime.AddHours(1) < currentTime).ToListAsync();
                if (reservations.Any())
                {
                    reservations.ForEach(x => x.Status = false);
                }
                await context.SaveChangesAsync();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
