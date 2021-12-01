﻿using System;
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

        private int itemID;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; propertyIsChanged(); }
        }

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

        private int category;

        public int Category
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
