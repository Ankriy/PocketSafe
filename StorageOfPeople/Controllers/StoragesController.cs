using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StorageOfPeople.Models.Storage;
using StorageOfPeople.Models.Storages;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskStorageOfPeople.Logic;
using TaskStorageOfPeople.Logic.Models.Users;
using TaskWebProject.Models.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StorageOfPeople.Controllers
{
    public class StoragesController : Controller
    {
        private readonly UserService _userService;
        public StoragesController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult StoragePeople()
        {
            var users = _userService.GetTestUsersList();

            CounterViewModel._To = (ushort)Math.Ceiling((float)users.Count / 10);
            CounterViewModel._Total = (ushort)users.Count;

            if (users.Count % 10 != 0 && CounterViewModel._From +1  == CounterViewModel._To || CounterViewModel._From == CounterViewModel._To)
                users = users.GetRange(CounterViewModel._From * 10, users.Count % 10);
            else
                users = users.GetRange(CounterViewModel._From * 10, 10);

            var model = new StorageNewViewModel(users);
            
            ViewData["from"] = CounterViewModel._From + 1;
            ViewData["to"] = CounterViewModel._To;

            return View(model);
        }
        [HttpPost]
        public IActionResult StoragePeople(string action)
        {
            if (CounterViewModel._From < CounterViewModel._To - 1)
            {
                if (action == "Вперед")
                {

                    CounterViewModel._From += 1;

                }
            }
            if (CounterViewModel._From >= 1)
            {
                if (action == "Назад")
                {
                    CounterViewModel._From -= 1;
                }
            }
            
            if (action == "Добавить")
            {
                return RedirectToAction("StorageAddPeople");
            }

            if (action == "Редактировать")
            {
                return RedirectToAction("StorageEditPeople");
            }

            //return View();
            return RedirectToAction("StoragePeople");
        }
        
        [HttpGet]
        public IActionResult StorageAddPeople()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StorageAddPeople(StorageCreateViewModel storage)
        {
            UserDTO user = new UserDTO() { Id= CounterViewModel._Total, Name = storage.Name, SurName = storage.SurName , Email = storage.Email };
            _userService.AddTestUsersList(user);
            return RedirectToAction("StoragePeople");
            //return View(storage);
            //return RedirectToAction("StorageEditPeople", new { id = CounterViewModel._Total });
        }
        [HttpGet]
        public IActionResult StorageEditPeople(int id)
        {
            var users = _userService.GetTestUsersList();
            var user = users.Where(u => u.Id == id).First();
            var task = new StorageViewModel()
            {
                Id = id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email
            };
            return View(task);
        }
        [HttpPost]
        public IActionResult StorageEditPeople(StorageViewModel users, string action) //Нажатие на кнопку для сохранения изменений
        {
            var listUsers = _userService.GetTestUsersList();
            var user = listUsers.Where(u => u.Id == users.Id);
            if (action == "Проверить")
            {
                return RedirectToAction("StorageEditPeople", new { id = users.Id });
            }
            if (action == "Сохранить")
            {
                for(int i = 0; i < listUsers.Count; i++)
                {
                    if (listUsers[i].Id == users.Id)
                    {
                        listUsers[i].Name = users.Name;
                        listUsers[i].SurName = users.SurName;
                        listUsers[i].Email = users.Email;
                    }
                }
                _userService.SetTestUsersList(listUsers);
            }
            return RedirectToAction("StoragePeople");
        }


    }
}
