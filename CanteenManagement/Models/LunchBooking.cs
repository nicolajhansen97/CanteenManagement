using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    public class LunchBooking : Bindable
    {
        private int _fldLunchBookingID;
        public int fldLunchBookingID
        {
            get { return _fldLunchBookingID; }
            set { _fldLunchBookingID = value; propertyIsChanged(); }
        }
        private int _fldEmployeeID;
        public int fldEmployeeID 
        {
            get { return _fldEmployeeID; }
            set { _fldEmployeeID = value; propertyIsChanged(); }
        }
        private string _fldDate;
        public string fldDate
        {
            get { return _fldDate; }
            set { _fldDate = value; propertyIsChanged(); }
        }
    }
}
