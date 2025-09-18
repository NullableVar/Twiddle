using Twiddle.Models;

namespace Twiddle.API.Core;

public interface ITokenProvider
{
    public string Create(UserModel user);
}