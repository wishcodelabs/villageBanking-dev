namespace VBMS.Domain.Models
{
    public class UploadFile
    {
        public string FileName { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        public string FileId { get; set; }

        public Guid OwnerGuid { get; set; }

        public int LoanApplicationId { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
    }
}
