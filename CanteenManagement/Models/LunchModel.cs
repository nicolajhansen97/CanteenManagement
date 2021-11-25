using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    class LunchModel : Models.Bindable
    {
        private string menu;

        public string Menu
        {
            get { return menu; }
            set { menu = value; propertyIsChanged(); }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; propertyIsChanged(); }
        }


    }
}
