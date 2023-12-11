using AutoMapper;
using BackEnd.Core.DTO.Doctor;
using BackEnd.Core.DTO.Specialization;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : BaseController<Doctor, DoctorGet, DoctorRegister,DoctorEdit, PaginationParam>

    {
        public DoctorsController(IRepositoryApp<Doctor> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
        
    }
}
