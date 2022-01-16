namespace VBMS.Worker.Services
{
    public class LoanPaymentsService : BackgroundService
    {

        private readonly ILogger<LoanPaymentsService> _logger;
        public LoanPaymentsService(ILogger<LoanPaymentsService> logger)
        {
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
