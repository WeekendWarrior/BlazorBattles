using BlazorBattles.Client.Services;
using BlazorBattles.Server.Data;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly DataContext _context;

        public UnitController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUnits()
        {
            var units = await _context.Units.ToListAsync();

            return Ok(units);
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();

            var updatedUnits = await _context.Units.ToArrayAsync();

            return Ok(updatedUnits);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnit(int id, Unit unit)
        {
            Unit dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);

            if (dbUnit == null) return NotFound($"Unit with id {id} does not exist.");

            dbUnit.Title = unit.Title;
            dbUnit.Attack = unit.Attack;
            dbUnit.Defense = unit.Defense;
            dbUnit.BananaCost = unit.BananaCost;
            dbUnit.HitPoints = unit.HitPoints;

            await _context.SaveChangesAsync();

            return Ok(dbUnit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            Unit dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);

            if (dbUnit == null) return NotFound($"Unit with id {id} does not exist.");

            _context.Units.Remove(dbUnit);
            await _context.SaveChangesAsync();

            var updatedUnits = await _context.Units.ToArrayAsync();

            return Ok(updatedUnits);
        }
    }
}
