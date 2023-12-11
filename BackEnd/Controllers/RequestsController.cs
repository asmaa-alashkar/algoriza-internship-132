using AutoMapper;
using BackEnd.Core.DTO.Request;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : BaseController<Request,RequestGet, RequestRegister,RequestEdit,PaginationParam>
    {
        public RequestsController(IRepositoryApp<Request> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
