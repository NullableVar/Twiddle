using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Daos.Interfaces;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Daos;

internal class UserDao(IMapper<UserModel, User> _userMapper, IMapper<User, UserModel> _userModelMapper) : IUserDao
{
    public async Task CreateAsync(UserModel userModel)
    {
        await using var context = new TwiddleDb();

        context.Add(_userMapper.Map(userModel));
        await context.SaveChangesAsync();
    }

    public async Task<UserModel?> GetByIdAsync(Guid id)
    {
        await using var context = new TwiddleDb();
        
        var userToReturn = context.Users.FirstOrDefault(u => u.Id == id);
        return userToReturn == null ? null : _userModelMapper.Map(userToReturn);
    }

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        await using var context = new TwiddleDb();
        
        var userToReturn = context.Users.FirstOrDefault(u => u.Email == email);
        return userToReturn == null ? null : _userModelMapper.Map(userToReturn);
    }

    public async Task<IList<UserModel>> GetAllAsync()
    {
        await using var context = new TwiddleDb();
        
        var usersToReturn = context.Users.ToList();
        return usersToReturn.Select(u => _userModelMapper.Map(u)).ToList();
    }

    public async Task UpdateAsync(UserModel model)
    {
        await using var context = new TwiddleDb();
        
        var userToUpdate = _userMapper.Map(model);
        context.Update(userToUpdate);
        await context.SaveChangesAsync(); 
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}