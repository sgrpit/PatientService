using AutoMapper;
using PatientService.Domain;
using PatientService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PatientsDetails, PatientReqDto>().ReverseMap();
                config.CreateMap<PatientResDto, PatientsDetails>().ReverseMap();
                config.CreateMap<AppointmentRequestDto, PatientAppointment>().ReverseMap();
                config.CreateMap<AppointmentResponseDto, PatientAppointment>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
