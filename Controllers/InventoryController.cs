using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepo;
        public InventoryController(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails([FromQuery] int productId, [FromQuery] int colorId, [FromQuery] int sizeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inventory = await _inventoryRepo.GetByDetailsId(productId, colorId, sizeId);

            if (inventory == null)
                return NotFound("Not exists");

            return Ok(inventory.ToInventoryDto());
        }

    }
}