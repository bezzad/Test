using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for mytreeviewpage.xaml
    /// </summary>
    public partial class mytreeviewpage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Mytreeviewmodel> MyModel { get; set; }

        public mytreeviewpage()
        {
            InitializeComponent();
            CreateTreeView();

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public void CreateTreeView()
        {
            MyModel = new ObservableCollection<Mytreeviewmodel>();
            MySubItem tempsubItem = new MySubItem("saeede");
            MySubItem tempsubItem2 = new MySubItem("saeede1");
            MySubItem tempsubItem3 = new MySubItem("saeede2");
            ObservableCollection<MySubItem> tempsubItems = new ObservableCollection<MySubItem>();
            tempsubItems.Add(tempsubItem);
            tempsubItems.Add(tempsubItem2);
            tempsubItems.Add(tempsubItem3); 
            MySubItem tempsubItem4 = new MySubItem("saeedeh");
            MySubItem tempsubItem5 = new MySubItem("saeedeh1");
            ObservableCollection<MySubItem> tempsubItems2 = new ObservableCollection<MySubItem>();
            tempsubItems2.Add(tempsubItem4);
            tempsubItems2.Add(tempsubItem5);

            Mytreeviewmodel tempItem = new Mytreeviewmodel("me", tempsubItems);
            Mytreeviewmodel tempItem2 = new Mytreeviewmodel("meh", tempsubItems2);


            ObservableCollection<Mytreeviewmodel> tempItemsList = new ObservableCollection<Mytreeviewmodel>();
            tempItemsList.Add(tempItem);
            tempItemsList.Add(tempItem2);

            MyModel = tempItemsList;

        }
        private void NotifyPropertyChanged( String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
