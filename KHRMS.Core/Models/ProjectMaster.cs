﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KHRMS.Core
{
    public class ProjectMaster : KHRMSBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "ProjectName is required")]
        public string? ProjectName { get; set; }

  
        [Required(ErrorMessage = "Description is required")]
        public String? Description { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "ClientName is required")]
        public string? ClientName { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "ClientRegion is required")]
        public string? ClientRegion {  get; set; }
    }
}
