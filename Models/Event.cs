using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eduhomee.Models
{
    public class Event
    {
        public int Id { get; set; }
       
        public string Location { get; set; }
        public string Description { get; set; }
        
        public DateTime Month { get; set; }
        public DateTime Day { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
