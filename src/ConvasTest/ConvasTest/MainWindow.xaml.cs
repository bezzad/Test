using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvasTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateDynamicCanvasPanel();
        }
        private void CreateDynamicCanvasPanel()
        {
            // Create a Canvas Panel control    
            //Canvas canvasPanel = new Canvas();
            // Set Canvas Panel properties    
            MyConvas.Background = new SolidColorBrush(Colors.LightCyan);
            // Add Child Elements to Canvas    
            Rectangle redRectangle = new Rectangle();
            redRectangle.Width = 200;
            redRectangle.Height = 200;
            redRectangle.Stroke = new SolidColorBrush(Colors.Black);
            redRectangle.StrokeThickness = 10;
            redRectangle.Fill = new SolidColorBrush(Colors.Red);
            // Set Canvas position    
            Canvas.SetLeft(redRectangle, 10);
            Canvas.SetTop(redRectangle, 10);
            // Add Rectangle to Canvas    
            MyConvas.Children.Add(redRectangle);
            // Add Child Elements to Canvas    
            Rectangle blueRectangle = new Rectangle();
            blueRectangle.Width = 200;
            blueRectangle.Height = 200;
            blueRectangle.Stroke = new SolidColorBrush(Colors.Black);
            blueRectangle.StrokeThickness = 10;
            blueRectangle.Fill = new SolidColorBrush(Colors.Blue);
            // Set Canvas position    
            Canvas.SetLeft(blueRectangle, 60);
            Canvas.SetTop(blueRectangle, 60);
            // Add Rectangle to Canvas    
            MyConvas.Children.Add(blueRectangle);
            // Add Child Elements to Canvas    
            Rectangle greenRectangle = new Rectangle();
            greenRectangle.Width = 200;
            greenRectangle.Height = 200;
            greenRectangle.Stroke = new SolidColorBrush(Colors.Black);
            greenRectangle.StrokeThickness = 10;
            greenRectangle.Fill = new SolidColorBrush(Colors.Green);
            // Set Canvas position    
            Canvas.SetLeft(greenRectangle, 110);
            Canvas.SetTop(greenRectangle, 110);
            // Add Rectangle to Canvas    
            MyConvas.Children.Add(greenRectangle);
            // Set Grid Panel as content of the Window    
            this.Content = MyConvas;
        }
    }
}
