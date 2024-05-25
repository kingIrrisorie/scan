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
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Manga manga, string NewAuthorName)
        {
            Manga mangaContext = manga;
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

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Mangas.Add(manga);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                }
               
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int IdManga)
        {
            return View(_context.Mangas.Find(IdManga));
        }

        [HttpPost]
        public IActionResult Update(Manga manga)
        {
            var mangaTemp = _context.Mangas.Find(manga.Id);

            mangaTemp.Title = manga.Title;


            _context.Mangas.Update(mangaTemp);
            _context.SaveChanges();
            return View();
        }
    }
}