using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenManagement.Models
{
    class ItemModel : Models.Bindable
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; propertyIsChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; propertyIsChanged(); }
        }


        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; propertyIsChanged(); }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; propertyIsChanged(); }
        }

        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; propertyIsChanged(); }
        }



    }
}
