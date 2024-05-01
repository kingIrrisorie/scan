using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace scan.Models
{
    public class MangaCreateViewModel
    {
        public Manga Manga {get;set;}
        public SelectList AuthorsList {get; set;}
        public int? SelectedAuthorId {get; set;}
        public string NewAuthorName {get;set;}
    }
}