using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.DTOs
{
    public class AppointmentResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public string EmployeeId { get; set; }
    }
}
