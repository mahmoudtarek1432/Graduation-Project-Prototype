using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prototype.data;
using Prototype.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prototype.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        private readonly Context _ctx;

        public SettingsController(Context context)
        {
            _ctx = context;
        }

        [HttpGet("")]
        public ActionResult<Settings> getSettings()
        {
            
            return _ctx.Settings.LastOrDefault();
        }

        [HttpPost("")]
        public async Task<ActionResult> UpdateSettings([FromBody] Settings stg)
        {
            await _ctx.Settings.AddAsync(stg);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpGet("OrderUpdate")]
        public ActionResult<bool> OrderUpdate()
        {
            var set = _ctx.Settings.LastOrDefault();
            if (set.OrderUpdated)
            {
                return true;
            }
            return false;
        }
    }
}
