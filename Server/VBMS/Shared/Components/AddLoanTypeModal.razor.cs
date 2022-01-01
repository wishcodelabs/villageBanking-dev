using System.Globalization;

namespace VBMS.Shared.Components
{
    public partial class AddLoanTypeModal
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public LoanType? Model { get; set; }
        [Parameter] public int VillageBankId { get; set; }
        public CultureInfo _en = CultureInfo.GetCultureInfo("en-ZM");
        Dictionary<string, object> _atri;

        protected override void OnInitialized()
        {
            _atri = new Dictionary<string, object>();
            if (!IsEditing)
            {
                Model = new LoanType();
            }
            _atri.Add("form", "editForm");
        }
        async void Submit()
        {

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();
    }
}
