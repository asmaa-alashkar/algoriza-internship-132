using AutoMapper;
using BackEnd.Core.DTO.Appointment;
using BackEnd.Core.DTO.Booking;
using BackEnd.Core.DTO.Discound;
using BackEnd.Core.DTO.Discount;
using BackEnd.Core.DTO.Doctor;
using BackEnd.Core.DTO.Patient;
using BackEnd.Core.DTO.Request;
using BackEnd.Core.DTO.Specialization;
using BackEnd.Core.DTO.Time;
using BackEnd.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Specialization, SpecializationGet>().ReverseMap();
            CreateMap<Specialization, SpecializationEdit>().ReverseMap();
            CreateMap<Specialization, SpecializationRegister>().ReverseMap();

            CreateMap<Doctor, DoctorGet>().ReverseMap();
            CreateMap<Doctor, DoctorEdit>().ReverseMap();
            CreateMap<Doctor, DoctorRegister>().ReverseMap();

            CreateMap<Patient, PatientGet>().ReverseMap();
            CreateMap<Patient, PatientRegister>().ReverseMap();
            CreateMap<Patient, PatientEdit>().ReverseMap();

            CreateMap<Discound, DiscoundEdit>().ReverseMap();
            CreateMap<Discound, DiscoundRegister>().ReverseMap();
            CreateMap<Discound, DiscoundGet>().ReverseMap();

            CreateMap<Appointment, AppointmentRegister>().ReverseMap();
            CreateMap<Appointment, AppointmentEdit>().ReverseMap();
            CreateMap<Appointment, AppointmentGet>().ReverseMap();

            CreateMap<Booking, BookingEdit>().ReverseMap(); 
            CreateMap<Booking, BookingGet>().ReverseMap();
            CreateMap<Booking, BookingRegister>().ReverseMap();

            CreateMap<Request, RequestEdit>().ReverseMap();
            CreateMap<Request, RequestGet>().ReverseMap();
            CreateMap<Request, RequestRegister>().ReverseMap();

            CreateMap<Time, TimeEdit>().ReverseMap();
        }
    }
}
