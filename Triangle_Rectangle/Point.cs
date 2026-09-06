using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle_Rectangle
{
    public class Point
    {
        public int X {  get; private set; }
        public int Y { get; private set; }


        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void AddX(int x)
        {
            X += x;
        }

        public void AddY(int y) 
        {
            Y += y; 
        }
    }
}
