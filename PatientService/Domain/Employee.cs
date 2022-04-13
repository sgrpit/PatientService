using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Domain
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public int EnployeeNumber { get; set; }
        public bool IsMedicalStaff { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CrteatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
