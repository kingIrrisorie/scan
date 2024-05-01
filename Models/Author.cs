using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace scan.Models
{
    public class Author
    {
        [Key]
        public int id {get;set;}
        [Required]
        [StringLength(20)]
        public string Name {get;set;}
        public List<Manga> Mangas {get;set;}
    }
}