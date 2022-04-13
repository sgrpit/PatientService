using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientService.DbContexts;
using PatientService.Domain;
using PatientService.DTOs;
using PatientService.Repos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Repos
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> DeletePatientDetails(string patientUHID)
        {
            try
            {
                PatientsDetails patientsDetails = await _dbContext.PatientsDetails.FirstOrDefaultAsync(p => p.PatientUHID == patientUHID);
                if(patientsDetails == null)
                    return false;
                _dbContext.PatientsDetails.Remove(patientsDetails);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PatientResDto>> GetAllPatient()
        {
            List<PatientsDetails> patients = await _dbContext.PatientsDetails.ToListAsync();
            return _mapper.Map<IEnumerable<PatientResDto>>(patients);
        }

        public async Task<string> GetLatestPatientUHID()
        {
            PatientsDetails patients = await _dbContext.PatientsDetails.OrderByDescending(p => p.PatientUHID).FirstOrDefaultAsync();
            return patients.PatientUHID;
        }

        public async Task<AppointmentResponseDto> GetPatientAppointmentScheduleDetails(string PatientUHID, string contactNo)
        {
            PatientAppointment patientAppointment = await _dbContext.PatientAppointment.FirstOrDefaultAsync(a => a.PatientUHID == PatientUHID);
            return _mapper.Map<AppointmentResponseDto>(patientAppointment);
        }

        public async Task<PatientsDetails> GetPatientDetailsByFilter(string UHID, string contactNo, string emailId = "")
        {
            return await _dbContext.PatientsDetails.FirstOrDefaultAsync(a => a.PatientUHID == UHID || a.ContactNo == contactNo || a.EmailId == emailId);
        }

        public async Task<PatientResDto> GetPatientDetailsByUHID(string patientUHID)
        {
            PatientsDetails patientsDetail = await _dbContext.PatientsDetails.FirstOrDefaultAsync(p => p.PatientUHID == patientUHID);
            return _mapper.Map<PatientResDto>(patientsDetail);
        }

        public async Task<PatientResDto> GetPatientDetailsContactNo(string contactNo)
        {
            PatientsDetails patientsDetail = await _dbContext.PatientsDetails.FirstOrDefaultAsync(p => p.ContactNo == contactNo);
            return _mapper.Map<PatientResDto>(patientsDetail);
        }

        public async Task<PatientResDto> PatientRegistration(PatientReqDto patientReqDto)
        {
            PatientsDetails patientsDetails = _mapper.Map<PatientsDetails>(patientReqDto);
            _dbContext.PatientsDetails.Add(patientsDetails);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PatientResDto>(patientsDetails);
        }

        public async Task<PatientAppointment> SchedulePatientAppointment(PatientAppointment appointment)
        {
            _dbContext.PatientAppointment.Add(appointment);
            await _dbContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<PatientResDto> UpdatePatientDetails(PatientReqDto patientReqDto)
        {
            PatientsDetails patientsDetails = _mapper.Map<PatientsDetails>(patientReqDto);
            _dbContext.PatientsDetails.Update(patientsDetails);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PatientResDto>(patientsDetails);
        }

    }
}
