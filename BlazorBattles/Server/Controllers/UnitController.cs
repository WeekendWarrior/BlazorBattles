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

        //[HttpGet]
        //public IActionResult GetUnits()
        //{
        //    _unitService.LoadUnitsAsync();

        //    return Ok(_unitService.Units);
        //}
    }
}
