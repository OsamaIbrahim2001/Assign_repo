using AssignmentTask_Api.IWork;
using AssignmentTask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentTask_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.RoomService.Get());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.RoomService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddEntity(Room room)
        {
            var res = await _unitOfWork.RoomService.Add(room);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult UpdateEntity(Room room)
        {
            var res = _unitOfWork.RoomService.Update(room);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEntity(int id)
        {
            var res = _unitOfWork.RoomService.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
    }
}
