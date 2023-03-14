using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Contracts;
using System.Drawing;
using TaskStorageOfPeople.Logic.Models.Users;


namespace TaskWebProject.Models.Tasks
{
    public class UserListViewModel
    {
        public List<UserShortViewModel> Users { get; set; }

        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public UserListViewModel()
        {
            Users = new List<UserShortViewModel>();
        }

        public UserListViewModel(UserListDTO list, int page, int size)
        {
            Users = new List<UserShortViewModel>();
            foreach (UserDTO task in list.Users)
            {
                Users.Add(new UserShortViewModel(task));
            }

            TotalCount = list.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
            CanBack = Page > 0;
        }

    }
}
