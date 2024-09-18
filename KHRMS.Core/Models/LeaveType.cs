using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KHRMS.Core.Models;

public class LeaveType : KHRMSBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }


    [StringLength(100)]
    [Required(ErrorMessage = "LeaveName is required")]
    public string? leaveName { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "LeaveType is required")]
    public string? leaveType { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "Leave Description is required")]
    public string? Description { get; set; }
  

    
}
