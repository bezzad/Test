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
    /// Interaction logic for _3DItem2.xaml
    /// </summary>
    public partial class _3DItem2 : UserControl
    {
        public _3DItem2()
        {
            InitializeComponent(); 
            
        }
        public void MyImage_next(int deley)
        {
            Storyboard storyboard = new Storyboard();
            var y3 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var y4 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 90);
            var rotateAnimation = new Rotation3DAnimation(y3, y4, TimeSpan.FromSeconds(1));
            rotateAnimation.BeginTime = TimeSpan.FromMilliseconds(deley);
            Storyboard.SetTarget(rotateAnimation, v2dv3d3);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin(this);

        }
        public void MyImage_pre(int deley)
        {
            Storyboard storyboard = new Storyboard();
            var y3 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 90);
            var y4 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var rotateAnimation = new Rotation3DAnimation(y3, y4, TimeSpan.FromSeconds(1));
            rotateAnimation.BeginTime = TimeSpan.FromMilliseconds(deley);
            Storyboard.SetTarget(rotateAnimation, v2dv3d3);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin(this);

        }
    }
}
