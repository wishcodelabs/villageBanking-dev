namespace VBMS.Shared.Components
{
    public partial class LoanApplicationFormModal
    {
        [CascadingParameter] MudDialogInstance DialogInstance { get; set; }

        [Parameter] public LoanApplication? Model { get; set; }

        [Parameter] public bool IsEditing { get; set; }

        [Parameter] public VillageGroupMembership Membership { get; set; }

        CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");
        Dictionary<string, object> _atri { get; set; }

        List<LoanType> loanTypes = new List<LoanType>();

        List<InvestmentPeriod> periods { get; set; } = new();



        protected override async void OnInitialized()
        {
            _atri = new Dictionary<string, object>
            {
                { "form", "editForm" }
            };
            if (!IsEditing)
            {
                Model = new();
            }
            else
            {

            }
            await Refresh();
        }

        async Task Refresh()
        {
            loanTypes = await loanTypeService.GetActive(Membership.VillageGroupId);
            periods = await investmentPeriodService.GetByStatusAsync(PeriodStatus.Open, Membership.VillageGroupId);
            StateHasChanged();
        }
        async Task Submit()
        {

        }
        async void AddFile()
        {

        }
        async void RemoveFile()
        {

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }

        void Cancel() => DialogInstance.Cancel();


    }
}
