namespace VBMS.Shared.Components
{
    public partial class AddInvestmentModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; } = false;
        [Parameter] public Investment? Model { get; set; }
        [Parameter] public int VillageBankId { get; set; }
        Dictionary<string, object> _attri { get; set; }
        public CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");
        List<InvestmentPeriod> periods { get; set; } = new List<InvestmentPeriod>();
        List<VillageGroupMembership> groupMemberships { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            _attri = new Dictionary<string, object>
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
            periods = await investmentPeriodService.GetByStatusAsync(PeriodStatus.Open, VillageBankId);
            groupMemberships = await membershipService.GetMembers(VillageBankId);

        }
        async Task Submit()
        {

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
