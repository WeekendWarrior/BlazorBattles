using BlazorBattles.Shared;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;
        private readonly IBananaService _bananaService;

        public UnitService(IToastService toastService, HttpClient http, IBananaService bananaService)
        {
            _toastService = toastService;
            _http = http;
            _bananaService = bananaService;
        }

        public event Action OnChange;

        public IList<Unit> Units { get; set; } = new List<Unit>();

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();

        void UnitsChanged() => OnChange.Invoke();

        public async Task AddUnit(int unitId)
        {
            var unit = Units.FirstOrDefault(unit => unit.Id == unitId);

            if (unit == null)
            {
                _toastService.ShowError($"Unable to find unitId {unitId}");

                return;
            }

            var result = await _http.PostAsJsonAsync("api/UserUnit", unitId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else
            {
                await _bananaService.GetBananas();

                _toastService.ShowSuccess($"Your {unit.Title} has been built!.", "Unit Built!");
            }

            UnitsChanged();
        }

        public async Task LoadUnitsAsync()
        {
            if (Units != null && Units.Count > 0) return;
            
            Units = await _http.GetFromJsonAsync<IList<Unit>>("api/unit");
        }

        public async Task LoadUserUnitsAsync()
        {
            MyUnits = await _http.GetFromJsonAsync<IList<UserUnit>>("api/UserUnit");
        }
    }
}
