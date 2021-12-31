namespace VBMS.Shared.Components
{
    public partial class AddPeriodModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public InvestmentPeriod? Model { get; set; }


        void Cancel() => MudDialog.Cancel();
        async Task Submit()
        {

        }
    }
}
