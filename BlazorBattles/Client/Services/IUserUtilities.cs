using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IUserUtilities
    {
        Task<int> GetCurrentUserIdAsync();
    }
}
