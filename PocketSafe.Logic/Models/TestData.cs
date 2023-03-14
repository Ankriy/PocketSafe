using System;
using System.Collections.Generic;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskStorageOfPeople.Logic.Models
{
    public static class TestData
    {
        private static List<UserDTO> _users;
        public static List<UserDTO> Users
        { 
            get
            {
                if (_users == null)
                {
                    Random rnd = new Random();
                    string[] n = { "Антон", "Вячеслав", "Добрыня", "Юрий", "Назар", "Викентий", "Артем", "Стефан", "Лев", "Лукьян", "Степан", "Ибрагим", "Николай", "Али", "Всеволод" };
                    string[] surn = { "Панкин", " Курневич", " Фаммус", " Майструк", " Горохин", " Койтасбаев", " Харзин", " Летов", " Цейдлиц", " Бесфамильный", " Лапин", " Монаков", " Кувшинов", " Половов", " Будников" };
                    _users = new List<UserDTO>();
                    for (int i = 0; i < 59; i++)
                    {
                        _users.Add(new UserDTO() { Id = i, Name = n[rnd.Next(0, 14)], SurName = surn[rnd.Next(0, 14)], Email = $"{n[rnd.Next(0, 14)][1..2]}"+$"{surn[rnd.Next(0, 15)][1..rnd.Next(2, 3)]}"+"@mail.ru" });
                    }
                }
                return _users;
            }
            set
            {
                _users = value;
            }
        }

    }
}
