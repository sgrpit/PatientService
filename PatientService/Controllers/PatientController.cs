using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientService.DTOs;
using PatientService.Repos.Interface;
using PatientService.Service;
using PatientService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepositry;
        private readonly IMapper _mapper;
        private readonly IPatientServices _patientService;
        public PatientController(IPatientRepository patientRepository, IMapper mapper, IPatientServices patientService)
        {
            _patientRepositry = patientRepository;
            _mapper = mapper;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatientDetails()
        {
            IEnumerable<PatientResDto> patientResponse =  await _patientRepositry.GetAllPatient();
            return Ok(patientResponse);
        }
        [HttpGet("UHID/{uhid}", Name="GetPatientByUHID")]
        public async Task<IActionResult> GetAllPatientDetailsByUHID(string uhid)
        {
            //also need to include billing details and discharge summary if patient is IPD
            PatientResDto patientRes = await _patientRepositry.GetPatientDetailsByUHID(uhid);
            return Ok(patientRes);
        }
        [HttpGet("ContactNo/{contactNo}", Name = "GetPatientByContactNo")]
        public async Task<IActionResult> GetAllPatientDetailsByMobileNo(string contactNo)
        {
            //also need to include billing details and discharge summary if patient is IPD
            PatientResDto patientRes = await _patientRepositry.GetPatientDetailsContactNo(contactNo);
            return Ok(patientRes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PatientResDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SavePatienDetails(PatientReqDto patientReqDto)
        {
            PatientResDto patientRes = await _patientService.CreateUpdatePatientDetails(patientReqDto);
            
            return Ok(patientRes);
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdatePatienDetails(int patientId, int patientUHID, int ContactNo)
        //{
        //    return Ok();
        //}
        [HttpDelete]
        public async Task<bool> DeletePatienDetails(int patientId, string patientUHID, string ContactNo)
        {
            await _patientRepositry.DeletePatientDetails(patientUHID);
            return true;
        }

        [HttpGet("GetAppointmentSchdule")]
        [ProducesResponseType(typeof(AppointmentResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPatientAppointment(string patientUHID = "", string contactNo = "")
        {
            AppointmentResponseDto responseDto = await _patientRepositry.GetPatientAppointmentScheduleDetails(patientUHID, contactNo);
            return Ok(responseDto);
        }
        [HttpPost("ScheduleAppointment")]
        [ProducesResponseType(typeof(AppointmentResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ScheduleAppointment(AppointmentRequestDto appointmentRequestDto)
        {
            AppointmentResponseDto responseDto = await _patientService.SchedulePatientApointment(appointmentRequestDto);
            return Ok(responseDto);
        }
        [HttpPut("CancelAppointment")]
        public async Task<IActionResult> CancelScheduledAppointment(int ContactNo)
        {
            return Ok();
        }
        [HttpPut("UpdateAppointmentDetails")]
        [ProducesResponseType(typeof(AppointmentResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateScheduledAppointmentDetails(int ContactNo)
        {
            return Ok();
        }

        [HttpGet("GetLabReport")]
        [ProducesResponseType(typeof(AppointmentResponseDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLabReportByUHIDOrContactNo(string UHID, string contactNo)
        {
            //this action will call report generation microservice.
            return Ok();
        }
    }
}
