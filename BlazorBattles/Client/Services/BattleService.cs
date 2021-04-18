using BlazorBattles.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class BattleService : IBattleService
    {
        private readonly HttpClient _http;

        public BattleResult LastBattle { get; set; } = new BattleResult();

        public BattleService(HttpClient http)
        {
            _http = http;
        }

        public async Task<BattleResult> StartBattle(int opponentId)
        {
            var result = await _http.PostAsJsonAsync("api/battle", opponentId);

            LastBattle = await result.Content.ReadFromJsonAsync<BattleResult>();

            return LastBattle;
        }
    }
}
