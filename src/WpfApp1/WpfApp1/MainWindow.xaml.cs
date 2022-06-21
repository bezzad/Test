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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Canvas _canvasObj = new Canvas();
        private _3DItem _leftframe;
        private _3DItem _leftframe2;
        private _3DItem2 _rightframe;
        private _3DItem2 _rightframe2;
        private _3DItem3 _centerframe;
        public MainWindow()
        {
            InitializeComponent();
            this.Content = _canvasObj;
            Grid mygrid = new Grid();
            _leftframe = new _3DItem();
            _leftframe2 = new _3DItem();
            _rightframe = new _3DItem2();
            _rightframe2 = new _3DItem2();
            _centerframe = new _3DItem3();
            mygrid.Children.Add(_centerframe);
            mygrid.Children.Add(_leftframe);
            mygrid.Children.Add(_leftframe2);
            mygrid.Children.Add(_rightframe);
            mygrid.Children.Add(_rightframe2);
            mygrid.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
            mygrid.MouseRightButtonDown += Grid_MouseRightButtonDown;
            mygrid.HorizontalAlignment = HorizontalAlignment.Center;
            mygrid.VerticalAlignment = VerticalAlignment.Center;
            
            Canvas.SetLeft(mygrid, 0);
            Canvas.SetTop(mygrid, 0);
            mygrid.Height = 200;
            mygrid.Width = 200;
            _canvasObj.Children.Add(mygrid);
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _leftframe.MyImage_next(1000);
            _leftframe2.MyImage_next(1100);
            _rightframe.MyImage_next(10);
            _rightframe2.MyImage_next(100);

        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _leftframe.MyImage_pre(0);
            _leftframe2.MyImage_pre(100);
            _rightframe.MyImage_pre(1000);
            _rightframe2.MyImage_pre(1100);

        }
    }
}
