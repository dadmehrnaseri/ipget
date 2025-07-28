using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ipget.Models;

namespace ipget.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public string? GetIp()
    {
        var ip = Request.HttpContext.Connection.RemoteIpAddress;
        if (ip != null)
        {
            ip = ip.MapToIPv4();
            var ipString = ip.ToString(); // This will give you the IPv4 format
            return ipString;
        }
        return null;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
