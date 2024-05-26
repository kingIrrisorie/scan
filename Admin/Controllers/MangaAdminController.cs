using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scan.Models;
using Microsoft.EntityFrameworkCore;
using scan.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using scan.Controllers;

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
                var existingAuthor = _context.Authors.FirstOrDefault(a => a.Name == NewAuthorName);
                if (existingAuthor != null)
                {
                    manga.AuthorId = existingAuthor.id;
                }
                else
                {
                    var newAuthor = new Author { Name = NewAuthorName };
                    _context.Authors.Add(newAuthor);
                    _context.SaveChanges();
                    manga.AuthorId = newAuthor.id;
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

        public IActionResult Search(string SearchTerm)
        {
            List<Manga> results = _context.Mangas
                            .Where(m => m.Title
                            .Contains(SearchTerm))
                            .ToList();
            
            return View(results);
        }

        [HttpGet]
        public IActionResult Update(int IdManga)
        {
            var manga = _context.Mangas.Find(IdManga);
            if (manga == null)
            {
                return BadRequest("Id is required.");
            }

            return View(manga);
        }

        [HttpPost]
        public IActionResult Update(Manga manga)
        {
            var mangaTemp = _context.Mangas.Find(manga.Id);
            if(mangaTemp == null)
            {
                BadRequest("Manga not exist");
            }

            mangaTemp.Title = manga.Title;
            mangaTemp.Description = manga.Description;
            // bloco de author
            

            _context.Mangas.Update(mangaTemp);
            _context.SaveChanges();
            return View();
        }
    }
}