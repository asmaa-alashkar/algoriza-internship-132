using AutoMapper;
using BackEnd.Core.DTO.Appointment;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController<Appointment, AppointmentGet, AppointmentRegister,AppointmentEdit,PaginationParam>
    {
        public AppointmentsController(IRepositoryApp<Appointment> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
