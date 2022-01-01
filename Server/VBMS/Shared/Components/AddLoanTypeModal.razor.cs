namespace VBMS.Shared.Components
{
    public partial class AddLoanTypeModal
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public LoanType? Model { get; set; }
        [Parameter] public int VillageBankId { get; set; }


        public CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");

        Dictionary<string, object> _atri { get; set; }

        protected override void OnInitialized()
        {
            _atri = new Dictionary<string, object>
            {
                { "form", "editForm" }
            };
            if (!IsEditing)
            {
                Model = new LoanType();
            }

        }
        async void Submit()
        {

            Model.GroupId = VillageBankId;
            if (IsEditing)
            {
                if (await loanTypeService.UpdateAsync(Model))
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
                if (await loanTypeService.AddAsync(Model))
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
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
