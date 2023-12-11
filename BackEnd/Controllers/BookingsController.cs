using AutoMapper;
using BackEnd.Core.DTO.Booking;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : BaseController<Booking,BookingGet,BookingRegister,BookingEdit,PaginationParam>
    {
        public BookingsController(IRepositoryApp<Booking> Repo, IMapper mapper) : base(Repo, mapper)
        {
        }
    }
}
