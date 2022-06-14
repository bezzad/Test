using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvasTest
{
    public class MySubItem
    {
        public string SubItemName { get; set; }

        public MySubItem(string subItemName)
        {
            SubItemName = subItemName;
        }
    }
    public class Mytreeviewmodel
    {
        public string ItemName { get; set; }
        public ObservableCollection<MySubItem> MySubItem { get; set; }

        public Mytreeviewmodel(string Name, ObservableCollection<MySubItem> mySubItem)
        {
            MySubItem = mySubItem;
            ItemName = Name;
        }
    }
}
