using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CanteenManagement.ViewModels.ItemPageViewModel;

namespace CanteenManagement.Models
{
    //Made by Nicolaj, Rasmus, Niels
    public class ItemModel : Models.Bindable
    {
        public Item Item { get; set; }

        private int fldItemInfoID;

        public int FldItemInfoID
        {
            get { return fldItemInfoID; }
            set { fldItemInfoID = value; propertyIsChanged(); }
        }

        private string fldItemName;

        public string FldItemName
        {
            get { return fldItemName; }
            set { fldItemName = value; propertyIsChanged(); }
        }

        private string fldItemDescription;

        public string FldItemDescription
        {
            get { return fldItemDescription; }
            set { fldItemDescription = value; propertyIsChanged(); }
        }


        private double fldPrice;

        public double FldPrice
        {
            get { return fldPrice; }
            set { fldPrice = value; propertyIsChanged(); }
        }

        private int fldCategoryTypeID;

        public int FldCategoryTypeID
        {
            get { return fldCategoryTypeID; }
            set { fldCategoryTypeID = value; propertyIsChanged(); }
        }

        private string fldImage;

        public string FldImage
        {
            get { return fldImage; }
            set { fldImage = value; propertyIsChanged(); }
        }



    }
}
