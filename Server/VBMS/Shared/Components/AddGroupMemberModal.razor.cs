

namespace VBMS.Shared.Components
{
    public partial class AddGroupMemberModal
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid? UserGuid { get; set; }
        int ProvinceId { get; set; } = 1;    
        [Parameter] public int VillageBankId { get; set; } = new();
        VillageGroupMembership GroupMembershipModel = new VillageGroupMembership();
        IEnumerable<VillageGroupRole> memberRoles { get; set; } = new List<VillageGroupRole>();
        protected override async Task OnInitializedAsync()
        {
            GroupMembershipModel.PersonalDetails = new();
            GroupMembershipModel.PersonalDetails.PhysicalAddress = new();
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
