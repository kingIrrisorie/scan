using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Azure;

namespace scan.Models
{
    public class Chapter
    {
        public int Id {get;set;}
        [Required]
        [ForeignKey("Manga")]
        public int MangaId {get;set;}
        public Manga Manga {get;set;}
        [Required]
        public string Title {get;set;}
        public ICollection<Page> Pages {get;set;}
    }
}