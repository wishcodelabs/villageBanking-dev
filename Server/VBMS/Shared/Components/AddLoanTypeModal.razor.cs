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

        protected override void OnInitialized()
        {
            if (!IsEditing)
            {
                Model = new LoanType();
            }
        }
        async void Submit()
        {

        }
        void ModelInvalid()
        {

        }
        void Cancel() => MudDialog.Cancel();
    }
}
