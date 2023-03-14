﻿using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly UserListService _userListService;
        public UsersController(UserService userService, UserListService userListService)
        {
            _userService = userService;
            _userListService = userListService;
        }

        [HttpGet]
        public IActionResult TableUsers([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;
            var skip = page * size;
            var userList = _userListService.Get(skip, size);
            var model = new UserListViewModel(userList, page , size);

            return View(model);


        }
        [HttpPost]
        public IActionResult TableUsers(ActionButton action)
        {
            switch (action)
            {
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
                    var taskId = _userService.EditUser(new UserEditDTO()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        SurName = user.SurName,
                        Email = user.Email
                    });
                    return RedirectToAction("TableUsers");
            }
            return RedirectToAction("TableUsers");
        }

        public enum ActionButton
        {
            Add,
            Edit,
            Check,
            Save
        }
    }
}
