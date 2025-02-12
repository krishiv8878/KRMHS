using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KHRMS.Core
{
    [Table("EmployeeDocuments")]

    public class EmployeeDocumentInfo: KHRMSBase
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "Document Name is required")]
        public string? DocumentName { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "File Path is required")]
        public string? FilePath { get; set; }

        [Required]
        [RegularExpression(@"\.(docx|doc|xaml|pdf)$", ErrorMessage = "Only .docx, .doc, .xaml and .pdf files are allowed.")]
        public string? DocumentExtension { get; set; }

        [Required(ErrorMessage = "Document Content is required")]
        public byte[]? DocumentContent { get; set; }
        public DateTime? UploadedDate { get; set; }
        public long UploadedBy { get; set; }
       
    }
}
