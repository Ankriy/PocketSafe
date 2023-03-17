using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PocketSafe.Logic.Models.Tasks;
using StorageOfPeople.Models.Storage;
using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskStorageOfPeople.Logic;
using TaskStorageOfPeople.Logic.Models.Users;
using TaskWebProject.Models.Tasks;
using static StorageOfPeople.Controllers.UsersController;

namespace StorageOfPeople.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        private readonly TaskListService _taskListService;
        public TasksController(TaskService taskService, TaskListService taskListService)
        {
            _taskService = taskService;
            _taskListService = taskListService;
        }

        [HttpGet]
        public IActionResult TableTasks([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size, int id)
        {
            if (size == 0)
                size = 10;

            var skip = page * size;
            var userList = _taskListService.Get(skip, size, id);
            var model = new TaskListViewModel(userList, page , size, id);

            return View(model);


        }
        [HttpPost]
        public IActionResult TableTasks()
        {
            return RedirectToAction("TableTasks");
        }
        [HttpGet]
        public IActionResult AddTask(int id)
        {
            ViewData["UserId"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(TaskCreateViewModel storage)
        {
            var Id = _taskService.AddTask(new TaskCreateDTO()
            {
                Id = TaskViewModel.TotalCount,
                Subject = storage.Subject,
                Description = storage.Description,
                UserId = storage.UserId
            }) ;
            return RedirectToAction("EditTask", new { id = Id});
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var user = _taskService.GetTask(id);
            var model = new TaskViewModel(user);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(TaskEditViewModel user)
        {
            var listUsers = _taskService.GetTestTasksList();

            var userId = _taskService.EditTask(new TaskEditDTO()
            {
                Id = user.Id,
                Subject = user.Subject,
                Description = user.Description,
                UserId = user.UserId
            });

            return RedirectToAction("TableTasks", new { id = userId});
        }


    }
}
