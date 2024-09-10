using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Core.Models
{
    public class Holiday : KHRMSBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Holidayname is required")]
        public string? HolidayName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public DateTime Description { get; set; }
        public bool IsOptional { get; set; }

    }
}
