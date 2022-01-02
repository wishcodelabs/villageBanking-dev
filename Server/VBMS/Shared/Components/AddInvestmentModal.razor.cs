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
            groupMemberships = await membershipService.GetMembersByStatus(VillageGroupMemberStatus.Active, VillageBankId);

        }
        async Task Submit()
        {
            var minA = await investmentPeriodService.GetCurrentThreshhold(Model.InvestmentPeriodId);
            if (Model.AmountInvested < minA)
            {
                snackBar.Add($"The minimum amount to invest this period is {minA.ToString("N2")} ZMW", Severity.Error);
                return;
            }
            else
            {
                if (!IsEditing)
                {
                    if (await investmentService.AddAsync(Model))
                    {
                        snackBar.Add("Record saved successifully.", Severity.Success);
                        MudDialog.Close(DialogResult.Ok(true));
                    }
                    else
                    {
                        snackBar.Add("Opps! Something went wrong, try again later.", Severity.Error);
                    }
                }
                else
                {
                    if (await investmentService.UpdateAsync(Model))
                    {
                        snackBar.Add("Record updated successifully.", Severity.Success);
                        MudDialog.Close(DialogResult.Ok(true));
                    }
                    else
                    {
                        snackBar.Add("Opps! Something went wrong, try again later.", Severity.Error);
                    }
                }
            }

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
