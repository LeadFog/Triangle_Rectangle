using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle_Rectangle
{
    public class MyRectangle
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }
        public Point P3 { get; private set; }
        public Point P4 { get; private set; }
        //Конструктор класса
        public MyRectangle(Point p1, Point p2, Point p3, Point p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public void AddX(int x)
        {
            P1.AddX(x);
            P2.AddX(x);
            P3.AddX(x);
            P4.AddX(x);
        }
        public void AddY(int y)
        {
            P1.AddY(y);
            P2.AddY(y);
            P3.AddY(y);
            P4.AddY(y);
        }
    }
}
