 using AutoMapper;
using BackEnd.Core.Common;
using BackEnd.Core.Helpers;
using BackEnd.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{

    public class BaseController<T, TDtoGet, TRegister, TEdit, TPagination> : ControllerBase
       where T : EntityBase
       where TDtoGet : class
       where TRegister : class
      where TEdit : class
      where TPagination : IPaginationParam
    {
        public readonly IRepositoryApp<T> _repo;
        protected readonly IMapper _mapper;


        public BaseController(
          IRepositoryApp<T> Repo,
          IMapper mapper 

       )
        {
            _repo = Repo;
            _mapper = mapper;
            //   _localizer = localizer;
            //_accssor = accssor;
        }
        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] TPagination paginationParam)
        {
            var entities = _repo.GetAll();





            if ((!string.IsNullOrEmpty(paginationParam.filterValue)))
                Filter(ref entities, paginationParam);
            if ((!string.IsNullOrEmpty(paginationParam.filterType)) && (!string.IsNullOrEmpty(paginationParam.sortType)))
                Sort(ref entities, paginationParam);

            var entitiesMapped = _mapper.ProjectTo<TDtoGet>(entities);

            var PagedList = await PagedList<TDtoGet>.CreateAsync(entitiesMapped, paginationParam.pageNumber, paginationParam.PageSize);



            Response.AddPagination(PagedList.CurrentPage, PagedList.PageSize, PagedList.TotalItems, PagedList.TotalPages);
            return Ok(PagedList);
        }
        //[HttpGet("getallList")]
        //public virtual async Task<IActionResult> GetallList()
        //{
        //    var repo = _repo.GetAll();
        //    var entities = await _mapper.ProjectTo<BaseListDto>(repo).ToListAsync();
        //    return Ok(entities);
        //}
        [HttpGet("getall")]
        // [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]

        public virtual async Task<IActionResult> GetAll([FromQuery] TPagination paginationParam)
        {
            var entities = _repo.GetAll();
            if ((!string.IsNullOrEmpty(paginationParam.filterType)) && (!string.IsNullOrEmpty(paginationParam.filterValue)))
                Filter(ref entities, paginationParam);

            var entitiesMapped = _mapper.ProjectTo<TDtoGet>(entities);
            var newentities = await entitiesMapped.ToListAsync();
            return Ok(newentities);
        }
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            var newEntity = _mapper.Map<TDtoGet>(entity);
            return Ok(newEntity);
        }

        [HttpPost("register")]
        // [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]

        public virtual async Task<IActionResult> Register([FromForm] TRegister TRegister)
        {
            var entity = _mapper.Map<T>(TRegister);
            LogRegister(ref entity);
            _repo.Add(entity);
            var result = await _repo.SaveAllAsync();
            if (result)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpPost("Edit/{id}")]
        public virtual async Task<IActionResult> Edit(int id, TEdit entityEdit)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            _mapper.Map(entityEdit, entity);
            LogEdit(ref entity);
            _repo.Update(entity);
            var result = await _repo.SaveAllAsync();
            if (result)
                return NoContent();
            else
                return BadRequest();
        }


        [HttpDelete("{id}")]
        // [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]
        public virtual async Task<IActionResult> DeleteById(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            _repo.Delete(entity);
            var result = await _repo.SaveAllAsync();
            if (result)
                return NoContent();
            else
                return BadRequest();
        }
        //[HttpDelete("DeleteSoft/{id}")]
        //// [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]

        //public virtual async Task<IActionResult> DeleteSoftById(int id)
        //{
        //    var entity = await _repo.GetByIdAsync(id);
        //    if (entity == null)
        //        return NotFound(_localizer["notfound"].Value);
        //    entity.IsDeleted = true;
        //    _repo.Update(entity);
        //    var result = await _repo.SaveAllAsync();
        //    if (result)
        //        return NoContent();
        //    else
        //        return BadRequest(_localizer["faildelete"].Value);
        //}

        //[HttpPost("DeleteRangeSoft")]
        //// [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]

        //public virtual async Task<IActionResult> DeleteRangeSoft([FromBody] params int[] arrayObject)
        //{
        //    List<T> entities = new List<T>();
        //    foreach (var id in arrayObject)
        //    {
        //        var entity = await _repo.GetByIdAsync(id);
        //        if (entity != null)
        //        {
        //            entity.IsDeleted = true;
        //            entities.Add(entity);

        //        }
        //    }
        //    _repo.UpdateRange(entities);
        //    var result = await _repo.SaveAllAsync();
        //    if (result)
        //        return NoContent();
        //    else
        //        return BadRequest(_localizer["faildelete"].Value);
        //}
        [HttpPost("DeleteRange")]
        // [Authorize(Roles = "hl-employee,hl-superadmin,hl-admin")]
        public virtual async Task<IActionResult> DeleteRange([FromBody] params int[] arrayObject)
        {
            List<T> entities = new List<T>();
            foreach (var id in arrayObject)
            {
                var entity = await _repo.GetByIdAsync(id);
                if (entity != null)
                    entities.Add(entity);
            }
            _repo.DeleteRange(entities);
            var result = await _repo.SaveAllAsync();
            if (result)
                return NoContent();
            else
                return BadRequest();
        }

        [NonAction]
        public virtual void Filter(ref IQueryable<T> entities, TPagination paginationParam)
        {
        }
        [NonAction]
        public virtual void Sort(ref IQueryable<T> entities, TPagination paginationParam)
        { }
        [NonAction]
        protected virtual void LogRegister(ref T entity)
        {
            //var userName = _accssor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            //entity.IPDeviceCreaded = entity.IPDeviceLastEdit = _accssor.HttpContext.Connection.RemoteIpAddress.ToString();
            //entity.CreatedDate = entity.LastEditDate = DateTime.Now;
            //entity.UserCreatedName = entity.UserLastEditName = userName;
            //entity.ClientId = entity.ClientId ?? Guid.NewGuid();

        }
        protected virtual void LogEdit(ref T entity)
        {
            //var userName = _accssor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            //entity.IPDeviceLastEdit = _accssor.HttpContext.Connection.RemoteIpAddress.ToString();
            //entity.UserLastEditName = userName;
            //entity.LastEditDate = DateTime.Now;
        }


    }
}
