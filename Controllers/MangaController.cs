using Microsoft.AspNetCore.Mvc;
using scan.Context;
using scan.Models;
using System.Linq;
using System.Collections.Generic;

namespace scan.Controllers
{
    public class MangaController : Controller
    {
        private readonly IronicusScanContext _context;

        public MangaController(IronicusScanContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SearchResults(string searchTerm)
        {
            List<Manga> results = [];
            if (!string.IsNullOrEmpty(searchTerm))
            {
                results = _context.Mangas
                    .Where(m => m.Title.Contains(searchTerm))
                    .ToList();
            }

            return View(results);
        }

        [HttpGet]
        public IActionResult Manga(int IdManga)
        {
            var manga = _context.Mangas.Find(IdManga);
            return View(manga);
        }
    }
}
