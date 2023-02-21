using Homework.Shared;
using Shared;

namespace Homework.Client.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> Login(Userr user);
    }
}
