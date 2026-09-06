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
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            Point p1 = new Point(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point p2 = new Point(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point p3 = new Point(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);

            // Рисуем его
            tr = new Triangle(p1, p2, p3);
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

        public void ClearScene()
        {
            //Очистка Canvas от всех объектов
            Scene.Children.Clear();
        }

    }
}