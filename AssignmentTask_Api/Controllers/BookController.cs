using AssignmentTask_Api.IWork;
using AssignmentTask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentTask_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.BookService.Get());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.BookService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddEntity(Book book)
        {
            var res = await _unitOfWork.BookService.Add(book);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult UpdateEntity(Book book)
        {
            var res = _unitOfWork.BookService.Update(book);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEntity(int id)
        {
            var res = _unitOfWork.BookService.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
    }
}
