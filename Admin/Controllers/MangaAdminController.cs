using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scan.Models;
using Microsoft.EntityFrameworkCore;
using scan.Context;

namespace scan.Admin.Controllers
{
    public class MangaAdminController : Controller
    {
        private readonly IronicusScanContext _context;
        public MangaAdminController(IronicusScanContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(){
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Manga manga)
        {
            if (ModelState.IsValid)
            {
                _context.Mangas.Add(manga);
                _context.SaveChanges();
                return RedirectToAction(nameof(Criar));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}