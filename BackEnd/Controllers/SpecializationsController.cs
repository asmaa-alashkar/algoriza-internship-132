using AutoMapper;
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
    public class SpecializationsController : BaseController<Specialization, SpecializationGet, SpecializationRegister, SpecializationEdit, PaginationParam>

    {
        public SpecializationsController(IRepositoryApp<Specialization> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
