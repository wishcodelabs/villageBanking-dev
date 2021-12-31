namespace VBMS.Shared.Components
{
    public partial class AddPeriodModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public InvestmentPeriod? Model { get; set; }
        [Parameter] public int VillageBankId { get; set; }

        protected override void OnInitialized()
        {
            if (!IsEditing)
            {
                Model = new();
            }
        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
        async Task Submit()
        {
            if (IsEditing)
            {

            }
            else
            {

            }
        }
    }
}
