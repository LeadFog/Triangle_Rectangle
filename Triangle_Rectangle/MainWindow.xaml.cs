using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Triangle_Rectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tr;
        MyRectangle rt;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            int maxX = 600;
            int maxY = 400;

            Point p1 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            Point p2 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            Point p3 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            tr = new Triangle(p1, p2, p3);

            // Создаём ПРЯМОУГОЛЬНИК (не 4 случайные точки!)
            int rectX = rnd.Next(50, maxX - 150);
            int rectY = rnd.Next(50, maxY - 100);
            int rectWidth = 150;
            int rectHeight = 100;

            Point rp1 = new Point(rectX, rectY); // Левый верхний
            Point rp2 = new Point(rectX + rectWidth, rectY); // Правый верхний
            Point rp3 = new Point(rectX + rectWidth, rectY + rectHeight); // Правый нижний
            Point rp4 = new Point(rectX, rectY + rectHeight); // Левый нижний
            rt = new MyRectangle(rp1, rp2, rp3, rp4);

            // Рисуем его
            DrawTriangle(tr);
            DrawRectangle(rt);

        }

        public void DrawLine(Point p1, Point p2)

        {
            //Создание новой линии
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();
            //Цвет и толщина линии
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            //Установка координат линии из координат точек Point2D
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            //Добавление линии в Canvas
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }

        public void DrawRectangle(MyRectangle rp)
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(rp.P1, rp.P2);
            DrawLine(rp.P2, rp.P3);
            DrawLine(rp.P3, rp.P4);
            DrawLine(rp.P4, rp.P1);
        }

        public void ClearScene()
        {
            //Очистка Canvas от всех объектов
            Scene.Children.Clear();
        }

    }
}