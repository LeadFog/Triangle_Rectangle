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
        MyRectangle rt;  // <-- Только здесь изменил Rectangle на MyRectangle (из-за конфликта имен)
        Random rnd = new Random();
        bool isTriangleActive = true;  // <-- Добавил: какая фигура активна

        public MainWindow()
        {
            InitializeComponent();

            int maxX = 600;
            int maxY = 400;

            Point p1 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            Point p2 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            Point p3 = new Point(rnd.Next(50, maxX), rnd.Next(50, maxY));
            tr = new Triangle(p1, p2, p3);

            int rectX = rnd.Next(50, maxX - 150);
            int rectY = rnd.Next(50, maxY - 100);
            int rectWidth = 150;
            int rectHeight = 100;

            Point rp1 = new Point(rectX, rectY);
            Point rp2 = new Point(rectX + rectWidth, rectY);
            Point rp3 = new Point(rectX + rectWidth, rectY + rectHeight);
            Point rp4 = new Point(rectX, rectY + rectHeight);
            rt = new MyRectangle(rp1, rp2, rp3, rp4);

            DrawTriangle(tr);
            DrawRectangle(rt);
        }


        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            MoveFigure(0, -10);
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            MoveFigure(0, 10);
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveFigure(-10, 0);
        }

        private void MoveRight_Click(object sender, RoutedEventArgs e)
        {
            MoveFigure(10, 0);
        }

        private void MoveFigure(int dx, int dy)
        {
            if (isTriangleActive)
            {
                tr.AddX(dx);
                tr.AddY(dy);
            }
            else
            {
                rt.AddX(dx);
                rt.AddY(dy);
            }
            Redraw();
        }

        private void SwitchFigure_Click(object sender, RoutedEventArgs e)
        {
            isTriangleActive = !isTriangleActive;

            if (isTriangleActive)
                ActiveFigureText.Text = "Треугольник";
            else
                ActiveFigureText.Text = "Прямоугольник";
        }

        private void Redraw()
        {
            Scene.Children.Clear();
            DrawTriangle(tr);
            DrawRectangle(rt);
        }

        // ========== ВАШ СТАРЫЙ КОД (без изменений) ==========

        public void DrawLine(Point p1, Point p2)
        {
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }

        public void DrawRectangle(MyRectangle rp)  // <-- Только здесь Rectangle -> MyRectangle
        {
            DrawLine(rp.P1, rp.P2);
            DrawLine(rp.P2, rp.P3);
            DrawLine(rp.P3, rp.P4);
            DrawLine(rp.P4, rp.P1);
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }
    }
}