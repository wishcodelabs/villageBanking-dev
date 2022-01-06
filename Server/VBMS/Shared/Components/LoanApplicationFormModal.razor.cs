using Syncfusion.Blazor.Inputs;

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

        List<UploadFile> uploadFiles { get; set; } = new List<UploadFile>();

        protected override async void OnInitialized()
        {
            _atri = new Dictionary<string, object>
            {
                { "form", "editForm" }
            };
            if (!IsEditing)
            {
                Model = new();
                Model.Files = new();
            }
            else
            {

            }
            await Refresh();
        }

        public async void OnFileRemove(RemovingEventArgs args)
        {
            foreach (var file in args.FilesData)
            {
                var userfile = Model.Files.FirstOrDefault(f => f.FileId == file.Id);
                if (!string.IsNullOrEmpty(userfile.FilePath))
                {
                    if (await uploadService.DeleteFileAsync(userfile.FilePath))
                    {
                        Model.Files.Remove(userfile);
                        snackBar.Add("File removed successifully", Severity.Success);
                    }
                    else
                    {
                        snackBar.Add("Could not delete the specified file. Try again later", Severity.Error);
                    }
                }
            }


        }
        async void UploadResults(UploadChangeEventArgs e)
        {

            foreach (var file in e.Files)
            {
                var fileName = await uploadService.UploadFileAsync(file.FileInfo.Name);
                if (!string.IsNullOrEmpty(fileName))
                {
                    snackBar.Add("File uploaded successifully", Severity.Success);
                    var userFile = new UploadFile
                    {
                        FileName = file.FileInfo.Name,
                        FileId = file.FileInfo.Id,
                        OwnerGuid = Membership.UserGuid,
                        FilePath = fileName,

                    };
                    Model.Files.Add(userFile);

                }
                else
                {
                    snackBar.Add("Could not upload the specified file. Try again later.", Severity.Error);
                }




            }
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
