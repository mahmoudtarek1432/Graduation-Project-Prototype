using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.data;
using Prototype.Model;

namespace Prototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public Context _ctx { get; }
        public ItemsController(Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("GetItems")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _ctx.Categories.Where(e => true).ToList();
            categories.ForEach(C => { C.items = _ctx.MenuItems.Where(i => i.CategoryId == C.Id).ToList(); });
            categories.ForEach(C => C.items.ForEach(i => i.category = null));
            return categories;
        }

        [HttpGet("GetItembyID/{Id}")]
        public ActionResult<MenuItem> GetCategories(int Id)
        {
            
            return _ctx.MenuItems.Where(mi=>mi.Id == Id).FirstOrDefault();
        }


        [HttpPost("createCategory")]
        public async Task<ActionResult> PostCategory([FromBody] string Name)
        {
            await _ctx.Categories.AddAsync(new Category
            {
                Name = Name
            });
            var set = _ctx.Settings.LastOrDefault();
            set.menuVersion = set.menuVersion + 1;
            _ctx.Settings.Update(set);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpPost("CreateItem")]
        public ActionResult createItem([FromBody] MenuItem item)
        {
            _ctx.MenuItems.AddAsync(item);
            var set = _ctx.Settings.LastOrDefault();
            set.menuVersion = set.menuVersion + 1;
            _ctx.Settings.Update(set);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteItem/{Id}")]
        public ActionResult DeleteItem(int Id)
        {
            _ctx.MenuItems.Remove(_ctx.MenuItems.Where(i=>i.Id == Id).FirstOrDefault());
            var set = _ctx.Settings.LastOrDefault();
            set.menuVersion = set.menuVersion + 1;
            _ctx.Settings.Update(set);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateItem")]
        public ActionResult UpdateItem([FromBody] MenuItem item)
        {
            var set = _ctx.Settings.LastOrDefault();
            set.menuVersion = set.menuVersion + 1;
            _ctx.Settings.Update(set);

            _ctx.MenuItems.Update(item);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
