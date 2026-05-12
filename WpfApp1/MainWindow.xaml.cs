using System;
using System.Text;
using System.Windows;

namespace TriangleWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Triangle triangle1 = CreateTriangle(
                    Triangle1SideA.Text,
                    Triangle1SideB.Text,
                    Triangle1SideC.Text);

                Triangle triangle2 = CreateTriangle(
                    Triangle2SideA.Text,
                    Triangle2SideB.Text,
                    Triangle2SideC.Text);

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("Треугольник #1");
                builder.AppendLine(triangle1.ToString());
                builder.AppendLine($"Существует: {triangle1.Exists()}");
                builder.AppendLine($"Площадь: {-triangle1:F2}");
                builder.AppendLine();

                builder.AppendLine("Треугольник #2");
                builder.AppendLine(triangle2.ToString());
                builder.AppendLine($"Существует: {triangle2.Exists()}");
                builder.AppendLine($"Площадь: {-triangle2:F2}");
                builder.AppendLine();

                builder.AppendLine(
                    $"Площадь 1 > Площади 2 : {triangle1 > triangle2}");

                builder.AppendLine(
                    $"Площадь 1 < Площади 2 : {triangle1 < triangle2}");

                ResultTextBox.Text = builder.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    exception.Message,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private Triangle CreateTriangle(
            string sideAText,
            string sideBText,
            string sideCText)
        {
            bool parsedA = double.TryParse(sideAText, out double sideA);
            bool parsedB = double.TryParse(sideBText, out double sideB);
            bool parsedC = double.TryParse(sideCText, out double sideC);

            if (!parsedA || !parsedB || !parsedC)
            {
                throw new Exception(
                    "Все стороны должны быть числами.");
            }

            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new Exception(
                    "Стороны должны быть больше нуля.");
            }

            return new Triangle(sideA, sideB, sideC);
        }
    }
}