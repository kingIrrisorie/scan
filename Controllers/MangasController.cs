using Microsoft.AspNetCore.Mvc;
using scan.Context;
using System.Linq;

namespace scan.Controllers
{
    public class MangasController : Controller
    {
        private readonly IronicusScanContext _context;
        public MangasController(IronicusScanContext context)
        {
            _context = context;
        }

        public IActionResult SearchManga()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchMangas(string searchTerm)
        {
            var results = _context.Mangas
                .Where(m => m.Title.Contains(searchTerm))
                .Select(m => new { m.Id, m.Title })
                .ToList();

            return PartialView("_MangaSearchResults", results);
        }
    }
}
