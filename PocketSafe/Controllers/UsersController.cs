using Microsoft.AspNetCore.Mvc;
using StorageOfPeople.Models.Storage;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskStorageOfPeople.Logic;
using TaskStorageOfPeople.Logic.Models.Users;
using TaskWebProject.Models.Tasks;

namespace StorageOfPeople.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult TableUsers()
        {
            var users = _userService.GetTestUsersList();

            UserViewModel.Take = (ushort)Math.Ceiling((float)users.Count / 10);
            UserViewModel.TotalCount = (ushort)users.Count;

            if (users.Count % 10 != 0 && UserViewModel.Skip +1  == UserViewModel.Take || UserViewModel.Skip == UserViewModel.Take)
                users = users.GetRange(UserViewModel.Skip * 10, users.Count % 10);
            else
                users = users.GetRange(UserViewModel.Skip * 10, 10);

            var model = new UserNewViewModel(users);
            
            ViewData["from"] = UserViewModel.Skip + 1;
            ViewData["to"] = UserViewModel.Take;

            return View(model);
        }
        [HttpPost]
        public IActionResult TableUsers(ActionButton action)
        {
            switch (action)
            {
                case ActionButton.Next:
                    if (UserViewModel.Skip < UserViewModel.Take - 1)
                    {
                        UserViewModel.Skip += 1;
                    }
                    break;
                case ActionButton.Back:
                    if (UserViewModel.Skip >= 1)
                    {
                        UserViewModel.Skip -= 1;
                    }
                        break;
                case ActionButton.Add:
                    return RedirectToAction("AddUser");
                case ActionButton.Edit:
                    return RedirectToAction("EditUser");
            }
            return RedirectToAction("TableUsers");
        }
        
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserCreateViewModel storage)
        {
            var userId = _userService.AddUser(new UserCreateDTO() { 
                                        Id= UserViewModel.TotalCount, 
                                        Name = storage.Name, 
                                        SurName = storage.SurName , 
                                        Email = storage.Email });
            return RedirectToAction("EditUser", new { id = userId });
        }
        [HttpGet]
        public IActionResult EditUser(int? id)
        {
            if(id != null)
            {
                var user = _userService.GetUser((int)id);
                var model = new UserViewModel(user);
                return View(model);
            }
            return View(new UserViewModel( new UserDTO()));
        }
        [HttpPost]
        public IActionResult EditUser(UserEditViewModel user, ActionButton action)
        {
            var listUsers = _userService.GetTestUsersList();
            switch (action)
            {
                case ActionButton.Check:
                    return RedirectToAction("EditUser", new { id = user.Id });
                case ActionButton.Save:
                    _userService.EditUser(new UserEditDTO() { Id = user.Id,
                                                        Name = user.Name,
                                                        SurName = user.SurName,
                                                        Email = user.Email});
                    break;
            }
            return RedirectToAction("TableUsers");
        }

        public enum ActionButton
        {
            Next,
            Back,
            Add,
            Edit,
            Check,
            Save
        }
    }
}
