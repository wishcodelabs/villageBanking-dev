namespace VBMS.Domain.Enums
{
    public enum Status : int
    {
        Pending,
        Approved
    }
    public enum LoanApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public enum LoanStatus
    {
        Pending,
        Due,
        Paid,
        Defaulted
    }
}
