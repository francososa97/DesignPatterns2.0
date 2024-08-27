using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private static readonly List<InventoryItem> Inventory = new List<InventoryItem>
    {
        new InventoryItem { ProductId = 1, QuantityInStock = 50 },
        new InventoryItem { ProductId = 2, QuantityInStock = 30 }
    };

    [HttpGet("{productId}")]
    public ActionResult<InventoryItem> Get(int productId)
    {
        var item = Inventory.Find(i => i.ProductId == productId);
        if (item == null) return NotFound();
        return item;
    }

    [HttpPost("adjust")]
    public ActionResult AdjustStock([FromBody] StockAdjustment adjustment)
    {
        var item = Inventory.Find(i => i.ProductId == adjustment.ProductId);
        if (item == null) return NotFound("Producto no encontrado en inventario.");

        item.QuantityInStock += adjustment.AdjustmentAmount;
        return Ok(item);
    }
}

public class InventoryItem
{
    public int ProductId { get; set; }
    public int QuantityInStock { get; set; }
}

public class StockAdjustment
{
    public int ProductId { get; set; }
    public int AdjustmentAmount { get; set; }
}
