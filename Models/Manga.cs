using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scan.Models
{
    public class Manga
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public string ImageUrl {get;set;}
        public string Summary {get;set;}
        public string Link {get;set;}
        public DateTime PostDate { get; set; } // Data de postagem do mangá
    }
}