namespace VBMS.Pages
{
    public partial class Dashboard
    {
        [CascadingParameter] protected Task<AuthenticationState> AuthenticationStateTask { get; set; }
        VillageBankGroup VillageBank { get; set; } = new();
        int[] searchData, clicksData, applyChartData, admissionData, consolData;
        int memberCount, currentPeriod, newLoanApplications, approvedLoans = 0;
        bool isAdmin = false;
        VillageGroupMembership Membership = new();
        double totalShares;
        decimal totalInvestments, totalDebt, totalEarnings, approvedPayments, newPayments, totalDeptors, totalRevenue, approvedInvestments, unApprovedInvestments = 0;
        List<InvestmentPeriod> openPeriods { get; set; } = new();
        ClaimsPrincipal claimsPrincipal = new();
        Guid userGuid;
        string image;
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        async Task Refresh()
        {
            if (isAdmin)
            {
                memberCount = await membershipService.CountMembers(VillageBank.Id);
                totalInvestments = await dashboardService.GetTotalInvestments(VillageBank.Id, currentPeriod);
                totalDeptors = await loanService.GetTotalDebtorsByGroup(VillageBank.Id, currentPeriod);
                approvedLoans = await dashboardService.GetApprovedLoanApplications(VillageBank.Id, currentPeriod);
                newLoanApplications = await dashboardService.GetNewLoanApplications(VillageBank.Id, currentPeriod);
                approvedInvestments = await dashboardService.GetByStatusAsync(Status.Approved, VillageBank.Id, currentPeriod);
                unApprovedInvestments = await dashboardService.GetByStatusAsync(Status.Pending, VillageBank.Id, currentPeriod);
                StateHasChanged();
            }
            else
            {
                var share = await memberShareService.GetMemberShare(currentPeriod, Membership.VillageGroupId, Membership.Id);
                approvedInvestments = share.TotalInvestment;
                approvedLoans = await loanApplicationService.GetMineByStatusAsync(Membership.Id, LoanApplicationStatus.Approved, currentPeriod);
                totalDebt = await loanService.GetTotalDebtByMembershipId(Membership.Id, currentPeriod);
                totalShares = share.NumberOfShares;
                image = Membership.PersonalDetails.Gender == Gender.Female ? "/images/female-icon.jpg" : "/images/male-icon.jpg";
                totalInvestments = await investmentService.GetUserTotalInvestments(Membership.UserGuid, currentPeriod);
                unApprovedInvestments = totalInvestments - approvedInvestments;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            searchData = new int[] { 10, 15, 25, 40 };
            clicksData = new int[] { 5, 30, 54, 40 };
            applyChartData = new int[] { 162, 200, 285, 400, 250, 50, 100 };
            admissionData = new int[] { 56, 100, 150, 63, 58, 300, 30 };
            consolData = new int[] { 25, 40, 35 };
            claimsPrincipal = (await AuthenticationStateTask).User;
            Membership.PersonalDetails = new();

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                userGuid = await userService.GetGuid(claimsPrincipal.Identity.Name);
                if ((await authorizationService.AuthorizeAsync(claimsPrincipal, this, "RequireAdminRole")).Succeeded)
                {
                    var admin = await groupAdminService.GetByUserGuid(userGuid);
                    if (admin != null)
                    {
                        VillageBank = admin.Group;
                        isAdmin = true;

                    }
                }
                else
                {
                    Membership = await membershipService.GetByGuid(userGuid);
                    VillageBank = Membership.VillageBankGroup;
                }
                openPeriods = await investmentPeriodService.GetByStatusAsync(PeriodStatus.Open, VillageBank.Id);
                await Refresh();
            }

        }
        async void ToggleActivateGroup()
        {
            var parameters = new DialogParameters { ["VillageBankId"] = VillageBank.Id, ["IsAdmin"] = true, ["UserGuid"] = userGuid };
            if (memberCount == 0)
            {
                var dialog = dialogService.Show<AddGroupMemberModal>("Complete Your Membership Form", parameters, maxWidth);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    if ((bool)result.Data)
                        await ActivateGroup();
                }

            }
            else
            {
                await ActivateGroup();
            }

        }
        async void Filter(int value)
        {
            currentPeriod = value;
            await Refresh();
            StateHasChanged();
        }
        async Task ActivateGroup()
        {
            if (await villageBankGroupService.ActivateGroup(VillageBank.Id))
            {
                snackBar.Add("Your group is now active", Severity.Success);
                var admin = await groupAdminService.GetByUserGuid(userGuid);
                VillageBank = new();
                VillageBank = admin.Group;
                StateHasChanged();
            }
            else
            {
                snackBar.Add("Something went wrong while trying to activate your group", Severity.Error);
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if ((await authorizationService.AuthorizeAsync(claimsPrincipal, this, "RequireAdminRole")).Succeeded)
            {

                await jsRuntime.InvokeVoidAsync("setup", new object[] { searchData, clicksData, applyChartData, admissionData, consolData });
            }
        }
    }
}
