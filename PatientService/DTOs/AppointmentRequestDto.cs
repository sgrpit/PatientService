using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.DTOs
{
    public class AppointmentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientUHID { get; set; }
        public string MiddleName { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public string BloodGroup { get; set; }
        public string AttendentId { get; set; }
        public string DiagnosisDetails { get; set; }


    }
}
