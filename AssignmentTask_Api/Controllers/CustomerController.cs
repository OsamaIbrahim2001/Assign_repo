using AssignmentTask_Api.IWork;
using AssignmentTask_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentTask_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.CustomerService.Get());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.CustomerService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddEntity(Customer customer)
        {
            var res = await _unitOfWork.CustomerService.Add(customer);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpPost]
        public IActionResult UpdateEntity(Customer customer)
        {
            var res = _unitOfWork.CustomerService.Update(customer);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEntity(int id)
        {
            var res = _unitOfWork.CustomerService.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok(res);
        }
    }
}
