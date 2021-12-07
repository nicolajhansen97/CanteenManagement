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

        public Lunch()
        {
            fldDate = "01/01/2000";
        }

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

        private bool fldMenuFinalized;
        public bool FldMenuFinalized
        {
            get { return fldMenuFinalized; }
            set { fldMenuFinalized = value; }
        }



    }
}
