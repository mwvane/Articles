using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace articles.Models
{
    public class Article
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(50,MinimumLength = 3 )]
        public string Title { get; set; }
        public string Description { get; set; }
    }


}