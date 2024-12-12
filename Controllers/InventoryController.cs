using api.DTOs.Inventory;
using api.DTOs.Product;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IColorRepository _colorRepo;
        private readonly ISizeRepository _sizeRepo;

        public InventoryController(IInventoryRepository inventoryRepo, IProductRepository productRepo,
                                    IColorRepository colorRepo, ISizeRepository sizeRepo)
        {
            _inventoryRepo = inventoryRepo;
            _colorRepo = colorRepo;
            _sizeRepo = sizeRepo;
            _productRepo = productRepo;
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] InventoryCreateDto inventoryCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _productRepo.ProductExists(inventoryCreateDto.ProductId))
                return BadRequest("Product dose not exist!");

            if (!await _sizeRepo.SizeExists(inventoryCreateDto.SizeId))
                return BadRequest("Size does not exist");

            if (!await _colorRepo.ColorExists(inventoryCreateDto.ColorId))
                return BadRequest("Color does not exist");

            if (await _inventoryRepo.InventoryExist(inventoryCreateDto.ProductId,
                                                    inventoryCreateDto.ColorId,
                                                    inventoryCreateDto.SizeId))
                return BadRequest("Inventory does exist");

            var inventoryDto = inventoryCreateDto.ToInventory();

            await _inventoryRepo.CreateAsync(inventoryDto);

            var productStock = new ProductUpdateAmountDto
            {
                Quantity = inventoryDto.Quantity,
                InStock = inventoryDto.InStock
            };

            //Update quantity, stock of product when create inventory
            var product = await _productRepo.UpdateAmountAsyns(inventoryDto.ProductId, productStock);

            return CreatedAtAction(nameof(GetDetails), new
            {
                productId = inventoryDto.ProductId,
                colorId = inventoryDto.Color,
                sizeId = inventoryDto.SizeId
            }, inventoryDto.ToInventoryDto());

        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll([FromQuery] InventoryQuery query)
        {
            var inventories = await _inventoryRepo.GetAllAsync(query);
            return Ok(inventories?.Select(i => i.ToInventoryALLDto()) ?? []);
        }

    }
}