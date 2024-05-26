using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace scan.Models
{
    public class Manga
    {
        public Manga()
        {
            Status = "Em progresso";
        }

        public int Id {get;set;}
        [Required]
        [StringLength(100)]
        public string Title {get;set;}
        public string Description {get;set;}
        [ForeignKey("Author")]
        public int? AuthorId {get;set;}
        public Author Author {get;set;}
        [Required]
        [RegularExpression("^(Em progresso|Finalizado|Abandonado)$")]
        public string Status {get;set;}
        [Display(Name = "Realese Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RealeseDate { get; set; } // Data de postagem do mangá
        public string? ImageUrl {get; set;}

        public ICollection<Chapter> Chapters {get;set;}
        public ICollection<Gender> Genders {get;set;}
    }
}