using PatientService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Service.Interface
{
    public interface IPatientServices
    {
        Task<PatientResDto> CreateUpdatePatientDetails(PatientReqDto patientReqDto);
        Task<AppointmentResponseDto> SchedulePatientApointment(AppointmentRequestDto appointmentDto);
        //Task<string> GetNewPatientUHID();

    }
}
