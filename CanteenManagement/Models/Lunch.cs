using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    //Made by Nicolaj, Rasmus, Niels
    public class Lunch : Models.Bindable
    {
        private string fldMenu;

        public string FldMenu
        {
            get { return fldMenu; }
            set { fldMenu = value; propertyIsChanged(); }
        }

        private string fldDate;

        public string FldDate
        {
            get { return fldDate; }
            set { fldDate = value; propertyIsChanged(); }
        }

        private string fldMenuDescription;

        public string FldMenuDescription
        {
            get { return fldMenuDescription; }
            set { fldMenuDescription = value; }
        }



    }
}
