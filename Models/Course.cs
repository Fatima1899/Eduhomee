using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eduhomee.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Writer { get; set; }
        public string Count { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}

