using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KHRMS.Core.Models
{
    public class AssetsMaster : KHRMSBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "AssetsMasterName is required")]
        public string? AssetsMasterName { get; set; }


        [Required(ErrorMessage = "AssetsMaster Description is required")]
        public DateTime? Description { get; set; }

        [Required(ErrorMessage = "SerialNumber IS required ")]
        public string? SerialNumber {  get; set; }

        [Required(ErrorMessage = "DateOfPurchase")]
        public DateTime? DateOfPurchase { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
