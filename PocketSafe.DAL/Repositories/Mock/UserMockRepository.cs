﻿using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketSafe.DAL.Repositories.Mock
{
    public class UserMockRepository : IUserRepository, IRepository<User>
    {
        private UserMockData _testUserData;

        public UserMockRepository(UserMockData testUserData)
        {
            _testUserData = testUserData;
        }


        public void Delete(int id)
        {
            var user = _testUserData.Users.FirstOrDefault(x => x.Id == id);
            _testUserData.Users.Remove(user);
        }

        public User Get(int id)
        {
            return _testUserData
                .Users
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<User> Get(Func<User, bool> where)
        {
            return _testUserData
                .Users
                .Where(where)
                .ToList();
        }

        public ICollection<User> Get(Func<User, bool> where, int skip, int take)
        {
            return _testUserData
                .Users
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
        public ICollection<User> Get(Func<User, bool> where, int id, int skip, int take)
        {
            return _testUserData
                .Users
                .Where(x => id == x.Id)
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetCount(Func<User, bool> where)
        {
            return _testUserData
                .Users
                .Where(where)
                .Count();
        }
        public int GetCount(Func<User, bool> where, int id)
        {
            return _testUserData
                .Users
                .Where(x => x.Id == id)
                .Where(where)
                .Count();
        }
        public User Save(User item)
        {
            if (item.Id <= 0)
            {
                item.Id = _testUserData.Users.Last().Id + 1;
                _testUserData.Users.Add(item);
                return item;
            }

            var user = _testUserData.Users.SingleOrDefault(x => x.Id == item.Id);
            user.Name = item.Name;
            user.SurName = item.SurName;
            user.Email = item.Email;
            return user;
        }
    }
}
