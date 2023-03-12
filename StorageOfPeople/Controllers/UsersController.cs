using Microsoft.AspNetCore.Mvc;
using StorageOfPeople.Models.Storage;
using System.Diagnostics.Metrics;
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

            CounterViewModel._To = (ushort)Math.Ceiling((float)users.Count / 10);
            CounterViewModel._Total = (ushort)users.Count;

            if (users.Count % 10 != 0 && CounterViewModel._From +1  == CounterViewModel._To || CounterViewModel._From == CounterViewModel._To)
                users = users.GetRange(CounterViewModel._From * 10, users.Count % 10);
            else
                users = users.GetRange(CounterViewModel._From * 10, 10);

            var model = new UserNewViewModel(users);
            
            ViewData["from"] = CounterViewModel._From + 1;
            ViewData["to"] = CounterViewModel._To;

            return View(model);
        }
        [HttpPost]
        public IActionResult TableUsers(ActionButton action)
        {
            switch (action)
            {
                case ActionButton.Next:
                    if (CounterViewModel._From < CounterViewModel._To - 1)
                    {
                        CounterViewModel._From += 1;
                    }
                    break;
                case ActionButton.Back:
                    if (CounterViewModel._From >= 1)
                    {
                        CounterViewModel._From -= 1;
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
            UserDTO user = new UserDTO() { Id= CounterViewModel._Total, Name = storage.Name, SurName = storage.SurName , Email = storage.Email };
            _userService.AddTestUsersList(user);
            return RedirectToAction("TableUsers");
            //return View(storage);
            //return RedirectToAction("StorageEditPeople", new { id = CounterViewModel._Total });
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var users = _userService.GetTestUsersList();
            var user = users.Where(u => u.Id == id).First();
            var task = new UserViewModel()
            {
                Id = id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email
            };
            return View(task);
        }
        [HttpPost]
        public IActionResult EditUser(UserEditViewModel users, ActionButton action)
        {
            var listUsers = _userService.GetTestUsersList();
            var user = listUsers.Where(u => u.Id == users.Id);
            switch (action)
            {
                case ActionButton.Check:
                    return RedirectToAction("EditUser", new { id = users.Id });
                case ActionButton.Save:
                    for (int i = 0; i < listUsers.Count; i++)
                    {
                        if (listUsers[i].Id == users.Id)
                        {
                            listUsers[i].Name = users.Name;
                            listUsers[i].SurName = users.SurName;
                            listUsers[i].Email = users.Email;
                        }
                    }
                    _userService.SetTestUsersList(listUsers);
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
