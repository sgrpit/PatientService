using AutoMapper;
using PatientService.Domain;
using PatientService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientService.Mapping
{
    public class PatientProfile: Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientsDetails, PatientReqDto>().ReverseMap();
        }

    }
}
