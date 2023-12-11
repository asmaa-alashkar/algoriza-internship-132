using AutoMapper;
using BackEnd.Core.DTO.Patient;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController :BaseController<Patient, PatientGet, PatientRegister,PatientEdit, PaginationParam>
    {
        public PatientsController(IRepositoryApp<Patient> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }

    }
}
