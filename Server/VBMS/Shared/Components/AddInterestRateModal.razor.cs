

using Microsoft.AspNetCore.Components.Forms;

namespace VBMS.Shared.Components
{
    public partial class AddInterestRateModal
    {
        EditForm form;
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
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
        async Task Submit()
        {

        }
        void ModelInvalid()
        {

        }
        void Cancel() => MudDialog.Cancel();
    }
}
