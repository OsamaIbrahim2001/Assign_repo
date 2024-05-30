using AssignmentTask_Api.Models;
using AssignmentTask_Api.Returns;
using Assignmnt_Task.ClientHelper;
using Assignmnt_Task.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Assignmnt_Task.Controllers
{
    public class RoomController:Controller
    {
        public async Task<IActionResult> Index()
        {
            var res = await HttpClientHelper.Get<Room>(UrlConstant.BaseUrl + RoomConstant.Get);
            return View(res.Value);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Post<Room, Room>(UrlConstant.BaseUrl + RoomConstant.AddEntity, room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }
        public ActionResult GetById()
        {
            return View();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ApiReturnObj<Room> res = null;
            if (ModelState.IsValid)
            {
                res = await HttpClientHelper.GetById<Room>(UrlConstant.BaseUrl + RoomConstant.GetById + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View(res);
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Room room)
        {
            if (ModelState.IsValid)
            {
                var res = await HttpClientHelper.Put(UrlConstant.BaseUrl + RoomConstant.UpdateEntity, room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
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
                var res = await HttpClientHelper.Delete(UrlConstant.BaseUrl + RoomConstant.DeleteEntity + "/" + id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
