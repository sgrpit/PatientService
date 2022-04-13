using PatientService.Domain;
using PatientService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Repos.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientResDto>> GetAllPatient();
        Task<PatientResDto> GetPatientDetailsByUHID(string patientUHID);
        Task<PatientResDto> GetPatientDetailsContactNo(string contactNo);
        Task<PatientResDto> PatientRegistration(PatientReqDto patientReqDto);
        Task<PatientResDto> UpdatePatientDetails(PatientReqDto patientReqDto);
        Task<bool> DeletePatientDetails(string patientUHID);
        Task<string> GetLatestPatientUHID();
        Task<PatientsDetails> GetPatientDetailsByFilter(string UHID, string contactNo, string emailId = "");
        Task<PatientAppointment> SchedulePatientAppointment(PatientAppointment appointmentDetails);
        Task<AppointmentResponseDto> GetPatientAppointmentScheduleDetails(string PatientUHID, string contactNo);
    }
}
