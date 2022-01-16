

namespace VBMS.Worker.Services
{
    public class LoanDueDatesService : BackgroundService
    {
        private readonly ILogger<LoanDueDatesService> logger;
        private readonly LoanService loanService;
        public LoanDueDatesService(ILogger<LoanDueDatesService> _logger, LoanService _loanService)
        {
            logger = _logger;
            loanService = _loanService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"Checking for due loans at {DateTime.Now.ToString("dd MMMM yyyy, H:mm")}");
                var loans = await loanService.GetDue();
                if (!loans.Any())
                {
                    logger.LogInformation("No Loans are due today.. ");
                }
                else
                {
                    logger.LogInformation($"{loans.Count} loan(s) are due today.. changing status.");
                    foreach (var loan in loans)
                    {
                        loan.Status = Domain.Enums.LoanStatus.Due;
                        if (await loanService.UpdateAsync(loan))
                        {
                            logger.LogInformation("Loan marked as due..");
                        }
                        else
                        {
                            logger.LogError("Failed to update loan status..");
                        }
                    }
                }
                await Task.Delay(86400000, stoppingToken);
            }
        }


    }
}
