using AutoMapper;
using PatientService.Domain;
using PatientService.DTOs;
using PatientService.Repos.Interface;
using PatientService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Service
{
    public class PatientServices: IPatientServices
    {
        private readonly IPatientRepository _patientRepository;
        private IMapper _mapper;

        public PatientServices(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientResDto> CreateUpdatePatientDetails(PatientReqDto patientReqDto)
        {            
            patientReqDto.PatientUHID = await GetNewPatientUHID();
            return await _patientRepository.PatientRegistration(patientReqDto);
        }

        public async Task<AppointmentResponseDto> SchedulePatientApointment(AppointmentRequestDto appointmentDto)
        {
            PatientsDetails patientDetails = await _patientRepository.GetPatientDetailsByFilter(appointmentDto.PatientUHID, appointmentDto.ContactNo);
            if(patientDetails != null)
                appointmentDto.PatientUHID = patientDetails.PatientUHID;
            PatientAppointment appointmentDetails = _mapper.Map<PatientAppointment>(appointmentDto);
            var appointmentResponse = await _patientRepository.SchedulePatientAppointment(appointmentDetails);
            return _mapper.Map<AppointmentResponseDto>(appointmentResponse);
        }

        private async Task<string> GetNewPatientUHID()
        {
            string newUHID = "UHID";
            string existingUHID = await _patientRepository.GetLatestPatientUHID();
            if (string.IsNullOrEmpty(existingUHID))
                newUHID = "00001";
            else
            {
                int numericValue = Convert.ToInt32(existingUHID.Replace("UHID", string.Empty)) + 1;
                if (Math.Floor(Math.Log10(numericValue) + 1) == 1)
                    newUHID = newUHID + "0000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 2)
                    newUHID = newUHID + "000" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newUHID = newUHID + "00" + Convert.ToString(numericValue);
                else if (Math.Floor(Math.Log10(numericValue) + 1) == 3)
                    newUHID = newUHID + "0" + Convert.ToString(numericValue);
                else
                    newUHID = newUHID + Convert.ToString(numericValue);
            }
            return newUHID;
        }

        

    }
}
