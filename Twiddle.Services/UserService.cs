using Twiddle.DataAccess.Database.Daos.Interfaces;
using Twiddle.Services.Interfaces;

namespace Twiddle.Services;

internal class UserService(IUserDao _userDao) : IUserService
{
    
}