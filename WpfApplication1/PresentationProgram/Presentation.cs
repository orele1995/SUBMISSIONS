using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProgram
{
    class Presentation
    {
        public List<Slide> Slides { get; private set; } = new List<Slide>();

       public Presentation ()
        {
            addSlide();
        }

        public void addSlide ()
        {
            Slides.Add(new Slide());
        }

    }
}
