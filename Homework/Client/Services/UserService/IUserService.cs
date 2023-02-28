using Homework.Shared.Entities;

namespace Homework.Client.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> Login(Userr user);
    }
}
