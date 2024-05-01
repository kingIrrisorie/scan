using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scan.Models;
using Microsoft.EntityFrameworkCore;
using scan.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Create()
        {
            var authors = _context.Authors.ToList();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Manga manga, string NewAuthorName)
        {
            if (!string.IsNullOrEmpty(NewAuthorName))
            {
                // Check if the new author already exists
                var existingAuthor = _context.Authors.FirstOrDefault(a => a.Name == NewAuthorName);
                if (existingAuthor != null)
                {
                    // If the author already exists, use their ID
                    manga.AuthorId = existingAuthor.id;
                }
                else
                {
                    // If the author doesn't exist, create and add the new author
                    var newAuthor = new Author { Name = NewAuthorName };
                    _context.Authors.Add(newAuthor);
                    _context.SaveChanges();
                    manga.AuthorId = newAuthor.id; // Set the new author's ID to the manga
                }
            }

            if (ModelState.IsValid)
            {
                _context.Mangas.Add(manga);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Reload authors if there's a need to return to the form
            var authors = _context.Authors.ToList();
            ViewBag.Authors = new SelectList(authors, "Id", "Name", manga.AuthorId);
            return View(manga);
        }

    }
}