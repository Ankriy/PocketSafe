using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageOfPeople.Models.Storage;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskStorageOfPeople.Logic;
using TaskStorageOfPeople.Logic.Models.Users;
using TaskWebProject.Models.Tasks;

namespace StorageOfPeople.Controllers
{
    public class TasksController : Controller
    {
        private readonly UserService _userService;
        private readonly UserListService _userListService;
        public TasksController(UserService userService, UserListService userListService)
        {
            _userService = userService;
            _userListService = userListService;
        }

        [HttpGet]
        public IActionResult TableTasks([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var userList = _userListService.Get(skip, size);
            var model = new UserListViewModel(userList, page , size);

            return View(model);


        }
        [HttpPost]
        public IActionResult TableTasks()
        {
            
            return RedirectToAction("TableUsers");
        }

        
    }
}
