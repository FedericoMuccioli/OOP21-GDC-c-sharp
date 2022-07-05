using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OOPGDC
{
    /// <summary>
    /// Utility class.
    /// This class is a dummy class and was implemented only to solve compilation problems.
    /// </summary>
    public class Utilities
    {
        private readonly Image img;

        public Utilities (){
            this.img = null;
        }

        /// <summary>
        /// Utility method to load an image given its path.
        /// </summary>
        /// <param name="path"> Path of the image. </param>
        /// <returns> The image requested. </returns>
        internal Image GetImage(String path)
        {
            return this.img; 
        }
    }
}
