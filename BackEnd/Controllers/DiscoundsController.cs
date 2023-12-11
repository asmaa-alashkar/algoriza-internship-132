using AutoMapper;
using BackEnd.Core.DTO.Discound;
using BackEnd.Core.DTO.Discount;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DiscoundsController : BaseController<Discound, DiscoundGet, DiscoundRegister, DiscoundEdit, PaginationParam>
    {
        public DiscoundsController(IRepositoryApp<Discound> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
