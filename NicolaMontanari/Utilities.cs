using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OOPGDC
{
    public class Utilities
    {
        private readonly Image img;


        public Utilities (){
            this.img = null;
        }


        internal Image GetImage(String path)
        {
            return this.img; 
        }
    }
}
