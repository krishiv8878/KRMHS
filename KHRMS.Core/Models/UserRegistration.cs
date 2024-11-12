using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace KHRMS.Core
{
    public class UserRegistration:KHRMSBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "FirstName is required")]
        public string? FirstName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "MobileNumber is required")]
        public string? MobileNumber { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }

    }
}
