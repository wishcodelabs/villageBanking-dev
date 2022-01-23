namespace VBMS.Shared.Components
{
    public partial class AddPeriodModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public InvestmentPeriod? Model { get; set; }
        [Parameter] public int VillageBankId { get; set; }
        public CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");
        public Dictionary<string, object> attri;
        protected override void OnInitialized()
        {
            attri = new();
            attri.Add("form", "editForm");
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
            Model.GroupId = VillageBankId;
            if (IsEditing)
            {

                if (await investmentPeriodService.UpdateAsync(Model))
                {
                    snackBar.Add("Updated Successifully", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackBar.Add("Something went wrong. Try again later.");
                }

            }
            else
            {

                if (await investmentPeriodService.AddAsync(Model))
                {
                    snackBar.Add("Saved Successifully", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackBar.Add("Something went wrong. Try again later.");
                }
            }
        }
    }
}
