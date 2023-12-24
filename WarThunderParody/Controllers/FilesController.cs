using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarThunderParody.Service.Interfaces;
using CsvHelper;

namespace WarThunderParody.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController :  ControllerBase
{
    private readonly IProductService _productService;

    public FilesController(IProductService productService)
    {
        _productService = productService;
    }

    [EnableCors("AllowAllMethods")]
    [HttpGet("GetJSONroducts")] 
    [Authorize(Roles = "Admin")]
    public async Task<string> GetJSONProducts()
    {
        var products = await _productService.GetProducts();
        string json = JsonConvert.SerializeObject(products.Data);
        System.IO.File.WriteAllText("Products.Json", json);

        var db = new WarThunderShopContext();
        return await db.UploadFile("Products.Json");
    }
    
    [EnableCors("AllowAllMethods")]
    [HttpGet("GetCSVProducts")]
    [Authorize(Roles = "Admin")]
    public async Task<string> GetCSVProducts()
    {
        var products = await _productService.GetProducts();
        using (var writer = new StreamWriter("Products.Csv"))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(products.Data);
        }
        var db = new WarThunderShopContext();
        return await db.UploadFile("Products.Csv");
    }
}