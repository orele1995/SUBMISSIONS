using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProgram
{
    class Slide
    {
       public String header { get; set; } = "New Slide";
       public List<String> body { get; set; } = new List<string>();

        public Slide()
        {
            body.Add("Write here...");         
        }
    }
}

