using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace TextViewer
{
    /// <summary>
    /// Interaction logic for renderPage.xaml
    /// </summary>
    public partial class renderPage 
    {
        private static int FormattedHeight;
        public renderPage()
        {
            InitializeComponent();
        }
        private string ReadFileContent()
        {
            return File.ReadAllText("D:\\projects\\textviewer\\TextViewer\\TextViewer\\tv.txt");
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            var currentText = ReadFileContent();
            var mainwidth = this.ActualWidth;
            var formattedText = new FormattedText(
                currentText,
                CultureInfo.GetCultureInfo("fa"),
                FlowDirection.RightToLeft,
                new Typeface("Calibri"),
                20,
                Brushes.Black)
            {
                MaxTextWidth = this.ActualWidth - 45,
            };
            FormattedHeight =(int) formattedText.Height;
            var o = this.ActualHeight;
            drawingContext.DrawText(formattedText, new Point(15, 15));
        }
        public static int GetHeight()
        {
            return FormattedHeight + 30;
        }
    }
}
