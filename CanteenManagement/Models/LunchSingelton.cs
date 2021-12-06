using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    public class LunchSingelton
    {
        private static ObservableCollection<Lunch> instance = null;

        public static ObservableCollection<Lunch> getInstance()
        {
            if (instance == null)
            {
                instance = new ObservableCollection<Lunch>();
            }
            return instance;
        }
    }
}
