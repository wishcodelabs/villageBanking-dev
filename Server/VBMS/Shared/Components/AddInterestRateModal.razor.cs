namespace VBMS.Shared.Components
{
    public partial class AddInterestRateModal
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; } = false;
        [Parameter] public LoanInterestRate? Model { get; set; }
        [Parameter] public LoanType Type { get; set; }
        [Parameter] public int VillageBankId { get; set; }
        Dictionary<string, object> _attri { get; set; }
        public CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");
        List<InvestmentPeriod> periods { get; set; } = new List<InvestmentPeriod>();
        protected override async Task OnInitializedAsync()
        {
            _attri = new Dictionary<string, object>
            {
                { "form", "editForm" }
            };

            if (!IsEditing)
            {
                Model = new LoanInterestRate();
            }
            else
            {

            }
            periods = await investmentPeriodService.GetByStatusAsync(PeriodStatus.Open, VillageBankId);

        }
        async void Submit()
        {
            Model.LoanTypeId = Type.Id;
            if (IsEditing)
            {
                var result = await loanInterestRateService.UpdateAsync(Model);
                if (result)
                {
                    snackBar.Add("Record Updated Successifully.", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackBar.Add("Something went wrong, Try again.", Severity.Error);
                }
            }
            else
            {
                var result = await loanInterestRateService.AddAsync(Model);
                if (result)
                {
                    snackBar.Add("Record Created Successifully.", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackBar.Add("Something went wrong, Try again.", Severity.Error);
                }
            }
        }
        void ModelInvalid()
        {
            snackBar.Add("Please select all the required fields", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
