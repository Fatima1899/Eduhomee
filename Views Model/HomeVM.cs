using Eduhomee.Models;
using System.Collections.Generic;

namespace Eduhomee.Views_Model
{
    public class HomeVM
    {
            public IEnumerable<Slider> sliders { get; set; }
            public IEnumerable<Board> boards { get; set; }
            public IEnumerable<EventBoard> eventBoards { get; set; }
            public IEnumerable<Engineering> engineerings { get; set; }
            public IEnumerable<Course> courses { get; set; }
            public IEnumerable<Event> events { get; set; }
            public IEnumerable<Bio> bios { get; set; }


    }
}
