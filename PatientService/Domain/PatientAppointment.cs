using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Domain
{
    public class PatientAppointment
    {
        [Key]
        public Guid Id { get; set; }
        public string PatientUHID { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsNoShow { get; set; }
        public string DiagnosisDetails { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
    }
}
