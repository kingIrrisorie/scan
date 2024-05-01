using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scan.Models
{
    public class Page
    {
        public int Id {get;set;}
        [Required]
        [ForeignKey("Chapter")]
        public int ChapterId {get; set;}
        public Chapter Chapter {get;set;}
        public int Number {get;set;}
        public string Url {get;set;}
    }
}