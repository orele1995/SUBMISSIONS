﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Cube
    {
        Random rnd = new Random();

        public int GetCubeValue ()
        {
            return rnd.Next(1, 7);
        }
             
    }
}
