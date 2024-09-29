using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NCrontab;

namespace Masc.MarkdownCICD.BackgroundServices
{
    public class CronBackgroundService : BackgroundService
    {
        private readonly string _cronExpression;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        public CronBackgroundService(string cronExpression)
        {
            _cronExpression = cronExpression;
            _schedule = CrontabSchedule.Parse(_cronExpression);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;

                if (now >= _nextRun)
                {
                    await Task.Run(() => DoWork(), stoppingToken);
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }

                var delay = _nextRun - DateTime.Now;
                if (delay.TotalMilliseconds <= 0)
                {
                    delay = TimeSpan.FromMilliseconds(500); // Minimum delay to prevent tight loop
                }

                await Task.Delay(delay, stoppingToken);
            }
        }

        private void DoWork()
        {
            // Your function to execute
            Console.WriteLine($"Task executed at {DateTime.Now}");
        }
    }
}