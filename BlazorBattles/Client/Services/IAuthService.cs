using BlazorBattles.Shared;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}
