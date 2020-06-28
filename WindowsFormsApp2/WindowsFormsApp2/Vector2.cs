using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{

    /*
     * 
     * STRUCT
     * 
     * */
    public class Vector2
    {
        //Constructor
        public Vector2(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public float x { get; private set; }
        public float y { get; private set; }

        //Get the length of the vector
        public float magnitude
        {
            get { return (float)Math.Sqrt((this.x * this.x) + (this.y * this.y)); }
        }

        //Get the square magnitude of vector. This runs quicky because it doesnt have a Math call. Good for simple comparsions
        public float srqMagnitude
        {
            get { return (x*x) + (y*y); }
        }

        //Returns this vector with a magnitude of 1
        public Vector2 normalized
        {
            get { return new Vector2(x/magnitude, y/magnitude); }
        }

        //Overload for Console.WriteLine()
        public override String ToString()
        {
            return "{" + x.ToString() + ", " + y.ToString() + "}";
        }
    }
}
