using Microsoft.AspNetCore.Mvc;
using ShopApi.Common;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        public static List<ItemDto> items = new List<ItemDto>
            {
                new ItemDto
                {
                Id = 1,
                Name = "Finlandia",
                Price = 35,
                Quantity = 1,
                ProductGroup = "Alcohol"
                },
                new ItemDto
                {
                Id = 2,
                Name = "Kanapka",
                Price = 8,
                Quantity = 2,
                ProductGroup = "Food"
                },

            };

        [HttpGet("GetItems")]
        public ActionResult<List<ItemDto>> Get()
        {
            return Ok(items);
        }

        [HttpGet("GetItem/{id}")]
        public ActionResult<ItemDto> GetById(int id)
        {
            var item = items.Find(c => c.Id == id);
            if (item == null)
            {
                return NotFound($"Customer with id: {id} not found!");
            }
            return item;
        }

        // BUG DO NOT ALLOWS ADDING ITEM WITH REQUIRED PRODUCT GROUP MEDICINE
        // BUG ALLOWS TO PASS QUANTITY = 0
        [HttpPost("CreateItem")]
        public ActionResult<List<ItemDto>> Create(ItemDto item)
        {
            items.Add(item);
            if(item.ProductGroup != "Alcohol" ^ item.ProductGroup != "Tobbaco" ^ item.ProductGroup != "Food")
            {
                return BadRequest("Item is in not required product group: Alcohol, Tobbaco, Food, Medicine");
            }

            if (item.Price == 0)
            {
                return BadRequest("Item price cannot be 0");
            }
            return Ok(items);
        }

        [HttpPut("UpdateItem")]
        public ActionResult<List<ItemDto>> Update(ItemDto request)
        {
            var item = items.Find(c => c.Id == request.Id);
            if (item == null)
            {
                return NotFound($"Customer with id: {request.Id} not found!");
            }
            item.Name = request.Name;
            item.Price = request.Price;
            item.Quantity = request.Quantity;
            item.ProductGroup = request.ProductGroup;

            return Ok(items);
        }

        // BUG NOT REMOVING ITEMS
        [HttpDelete("DeleteItem/{id}")]
        public ActionResult<List<ItemDto>> Delete(int id)
        {
            var item = items.Find(c => c.Id == id);
            if (item == null)
            {
                return NotFound($"Customer with id: {id} not found!");
            }
            return Ok(items);
        }
    }
}
