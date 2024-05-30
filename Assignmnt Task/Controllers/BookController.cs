using AssignmentTask_Api.Models;
using AssignmentTask_Api.Returns;
using Assignmnt_Task.ClientHelper;
using Assignmnt_Task.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Assignmnt_Task.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var res = await HttpClientHelper.Get<Book>(UrlConstant.BaseUrl + BookConstant.Get);
            return View(res.Value);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Post<Book, Book>(UrlConstant.BaseUrl + BookConstant.AddEntity, book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public ActionResult GetById()
        {
            return View();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ApiReturnObj<Book> res=null;
            if (ModelState.IsValid)
            {
                 res = await HttpClientHelper.GetById<Book>(UrlConstant.BaseUrl + BookConstant.GetById + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View(res);
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Put(UrlConstant.BaseUrl + BookConstant.UpdateEntity, book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
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
                var res = await HttpClientHelper.Delete(UrlConstant.BaseUrl + BookConstant.DeleteEntity + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
