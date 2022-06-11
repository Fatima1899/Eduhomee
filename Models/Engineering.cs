using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eduhomee.Models
{
    public class Engineering
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
