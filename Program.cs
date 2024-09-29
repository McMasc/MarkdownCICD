using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Masc.MarkdownCICD.BackgroundServices;
using Masc.MarkdownCICD.Repositories;

namespace Masc.MarkdownCICD
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
                // TODO
                var cicdFileInfo = Services.MarkdownFiles.GetCICDJobsFile();
                var cicdTasks = Services.MarkdownFiles.GetTasks(cicdFileInfo);

                
                var markdownDailyFileInfo = Services.MarkdownFiles.GetCurrentDaily();
                Services.Markdown.AddHeader(markdownDailyFileInfo, level: 1, title: "title", afterHeader: lastHeader);
                fileInfo.Update();
            */

            var test = new MarkdownRepository("TestVault/cicd.md");

            /*
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    var cronExpression = "0 0 * * *"; // Runs every 5 seconds
                    services.AddHostedService(provider => new CronBackgroundService(cronExpression));
                })
                .Build();

            await host.RunAsync();
            */
        }
    }
}