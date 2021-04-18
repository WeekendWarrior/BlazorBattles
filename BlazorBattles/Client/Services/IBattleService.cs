﻿using BlazorBattles.Shared;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IBattleService
    {
        BattleResult LastBattle { get; set; }

        Task<BattleResult> StartBattle(int opponentId);
    }
}
