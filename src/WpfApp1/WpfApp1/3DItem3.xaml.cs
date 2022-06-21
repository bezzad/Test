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
    /// Interaction logic for _3DItem3.xaml
    /// </summary>
    public partial class _3DItem3 : UserControl
    {

        public _3DItem3()
        {
            InitializeComponent();
            Storyboard storyboard = new Storyboard();
            var y1 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            var y2 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 90);
            var rotateAnimation2 = new Rotation3DAnimation(y1, y2, TimeSpan.FromSeconds(1));
            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(rotateAnimation2, v2dv3d4);
            Storyboard.SetTargetProperty(rotateAnimation2, new PropertyPath("(Viewport2DVisual3D.Transform).(RotateTransform3D.Rotation)"));
            storyboard.Begin(this);
        }
    }
}
