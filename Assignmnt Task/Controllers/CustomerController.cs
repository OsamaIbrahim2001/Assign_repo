using AssignmentTask_Api.Models;
using AssignmentTask_Api.Returns;
using Assignmnt_Task.ClientHelper;
using Assignmnt_Task.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Assignmnt_Task.Controllers
{
    public class CustomerController:Controller
    {
        public async Task<IActionResult> Index()
        {
            var res = await HttpClientHelper.Get<Customer>(UrlConstant.BaseUrl + CustomerConstant.Get);
            return View(res.Value);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Post<Customer, Customer>(UrlConstant.BaseUrl + CustomerConstant.AddEntity, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public ActionResult GetById()
        {
            return View();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ApiReturnObj<Customer> res = null;
            if (ModelState.IsValid)
            {
                res = await HttpClientHelper.GetById<Customer>(UrlConstant.BaseUrl + CustomerConstant.GetById + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View(res);
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Put(UrlConstant.BaseUrl + CustomerConstant.UpdateEntity, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Delete(UrlConstant.BaseUrl + CustomerConstant.DeleteEntity + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
