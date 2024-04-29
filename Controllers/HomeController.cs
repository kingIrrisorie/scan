using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using scan.Context;

namespace scan.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IronicusScanContext _context;

    public HomeController(ILogger<HomeController> logger, IronicusScanContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Busca os mangás ordenados pela data de postagem, exibindo os mais recentes primeiro
        var latestMangas = await _context.Mangas.OrderByDescending(m => m.PostDate).ToListAsync();

        return View(latestMangas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
