﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KHRMS.Core
{
    [Table("EmployeePaymentInfo")]

    public class EmployeePaymentInfo : KHRMSBase
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("EmployeeId")]
        [Required(ErrorMessage = "Employee is required")]

        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "BankName is required")]
        [StringLength(100)]
        public string BankName { get; set; }

        [Required(ErrorMessage = "IFSC Code is required")]
        [StringLength(20)]
        public string IFSCCode { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        public long AccountNumber { get; set; }

        public string NameOnAccount { get; set; }

    }
}

