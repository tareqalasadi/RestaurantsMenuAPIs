using Microsoft.AspNetCore.Mvc;
using RestaurantsMenu.Models;
using RestaurantsMenu.Repository;

namespace RestaurantsMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(menus);
        }

        [HttpGet("GetMenuById/{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost("AddMenu")]
        public async Task<IActionResult> AddMenu([FromBody] Menu menu)
        {
            if (await _menuService.AddMenuAsync(menu))
                return CreatedAtAction(nameof(GetMenuById), new { id = menu.Id }, menu);
            return BadRequest();
        }

        [HttpPut("UpdateMenu/{id}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] Menu menu)
        {
            if (id != menu.Id) return BadRequest();
            if (await _menuService.UpdateMenuAsync(menu))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("DeleteMenu/{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            if (await _menuService.DeleteMenuAsync(id))
                return Ok();
            return BadRequest();
        }
    }
}
