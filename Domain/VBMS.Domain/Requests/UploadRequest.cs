namespace VBMS.Domain.Requests
{
    public class UploadRequest : AuditableEntity<int>
    {
        public string FileName { get; set; }

        public string Description { get; set; }

        public ContentType ContentType { get; set; }

        public string FileId { get; set; }

        public Guid OwnerGuid { get; set; }

        public int LoanApplicationId { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
    }
}
