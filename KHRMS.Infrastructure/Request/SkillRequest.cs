using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Infrastructure.Request
{
    public class SkillRequest
    {
        [StringLength(100)]
        [Required(ErrorMessage = "SKillName is required")]
        public string? SkillName { get; set; }

        public bool? IsActive { get; set; }

    }
}
