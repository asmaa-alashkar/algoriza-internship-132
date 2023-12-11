using AutoMapper;
using BackEnd.Core.DTO.Time;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : BaseController<Time,TimeGet,TimeRegister,TimeEdit,PaginationParam>
    {
        public TimesController(IRepositoryApp<Time> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
