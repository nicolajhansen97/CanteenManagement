using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    public class CollectionSingelton
    {
        private static ObservableCollection<Item> instance = null;

        public static ObservableCollection<Item> getInstance()
        {
            if (instance == null)
            {
                instance = new ObservableCollection<Item>();
            }
            return instance;
        }
    }
}
