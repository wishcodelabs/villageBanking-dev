namespace VBMS.Shared.Components
{
    public partial class SimpleDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public string ContentText { get; set; }
        string BodyText { get; set; }

        [Parameter] public DialogType DialogType { get; set; }

        string ButtonText { get; set; }
        string icon;
        Color Color { get; set; }
        protected override void OnInitialized()
        {
            switch (DialogType)
            {
                case DialogType.Delete:
                    ButtonText = "Delete";
                    Color = Color.Error;
                    icon = Icons.Material.Filled.DeleteForever;
                    BodyText = $"Do you want to delete {ContentText} ? this action can not be undone";
                    break;
                case DialogType.Alert:
                    ButtonText = "Ok";
                    Color = Color.Primary;
                    BodyText = ContentText;
                    break;
                case DialogType.Confirm:
                    ButtonText = "Confirm";
                    Color = Color.Primary;
                    BodyText = ContentText;
                    break;
                default:
                    break;
            }
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}
