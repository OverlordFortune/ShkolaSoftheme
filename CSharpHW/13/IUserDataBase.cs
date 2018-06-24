using System;
using _12._1;
namespace _13._1
{
    interface IUserDataBase : IDisposable
    {
        User[] GetAllUser();
        User FindByName(string Name);
        void AddUser(User user);
    }
}
