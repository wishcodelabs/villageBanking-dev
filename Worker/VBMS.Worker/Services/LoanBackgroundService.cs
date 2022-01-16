

namespace VBMS.Worker.Services
{
    public class LoanBackgroundService : BackgroundService
    {
        private readonly ILogger<LoanBackgroundService> logger;
        private readonly LoanService loanService;
        public LoanBackgroundService(ILogger<LoanBackgroundService> _logger, LoanService _loanService)
        {
            logger = _logger;
            loanService = _loanService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"Checking for due loans at {DateTime.Now:F}");
                var dueLoans = await loanService.GetDue();
                logger.LogInformation($"Checking for defaulted loans at {DateTime.Now:F}");
                var defaultedLoans = await loanService.GetDefaulted();
                if (!dueLoans.Any())
                {
                    logger.LogInformation("No Loans are due today.. ");
                }
                else
                {
                    logger.LogInformation($"{dueLoans.Count} loan(s) are due today.. changing status.");
                    foreach (var loan in dueLoans)
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
                if (!defaultedLoans.Any())
                {
                    logger.LogInformation("No defaulted loans today.");
                }
                else
                {
                    logger.LogInformation($"{defaultedLoans.Count} loan(s) are default today.. changing status.");
                    foreach (var loan in defaultedLoans)
                    {
                        loan.Status = Domain.Enums.LoanStatus.Defaulted;
                        if (await loanService.UpdateAsync(loan))
                        {
                            logger.LogInformation("Loan marked as default..");
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
