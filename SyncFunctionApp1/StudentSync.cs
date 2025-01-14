using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SyncFunctionApp1
{
    public class StudentSync
    {
        private readonly ILogger _logger;

        public StudentSync(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<StudentSync>();
        }

        [Function("StudentSync")]
        public void Run([TimerTrigger("0 */1 * * * *", RunOnStartup =true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
