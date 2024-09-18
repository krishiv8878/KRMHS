﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KHRMS.Core
{
    public class Designation : KHRMSBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "DesignationName is required")]
        public string? DesignationName { get; set; }

        
    }
}
