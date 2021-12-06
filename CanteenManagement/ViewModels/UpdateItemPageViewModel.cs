using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    class UpdateItemPageViewModel : Bindable, IUpdateItemPageViewModel
    {

        public ICommand ChangeToItemPageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }
        public ICommand UpdateItemCMD { get; set; }

        //Getters and setters for the textfields.
        public static int ItemInfoID { get; set; }
        public static int CategoryID { get; set; }
        public static string Name { get; set; }
        public static string Description { get; set; }
        public static double Price { get; set; }
        public static string Image { get; set; }

        public UpdateItemPageViewModel()
        {

            ChangeToItemPageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<ItemView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            UpdateItemCMD = new RelayCommand(() =>
            {
                UpdateItemRunAsync();
            });
        }
       
        /*Made by Nicolaj and Monir
         * 
         * Creates a instance of a new ItemModel and bound to the new input, so it will be saved as whatever is put in the textfields.
        */
         async Task UpdateItemRunAsync()
        {
            Item item = new Item();

            try
            {

                // Update the product
                item.FldItemInfoID = ItemInfoID;
                item.FldCategoryTypeID = CategoryID;
                item.FldItemName = Name;
                item.FldItemDescription = Description;
                item.FldPrice = Price;
                item.FldImage = Image;

                await UpdateProductAsync(item);

                //Removes the selected item from the list.
                CollectionSingelton.getInstance().Remove(ItemPageViewModel.SelectedItem);

                //Adds the item at the list again with the updated values.
                CollectionSingelton.getInstance().Add(item);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
 

        /* Made by Nicolaj 
         * 
         * Updates the product async. Takes the info from UpdateItemRunASync and put it as Json and updates it. 
         * Then it changes the view back to ItemView. The exceptions will be caught at UpdateItemRunAsync so there is exception handeling.
        */
         async Task<Item> UpdateProductAsync(Item item)
        {

            HttpResponseMessage response = await ApiHelper.client.PutAsJsonAsync(ApiHelper.serverUrl + ApiHelper.getItems + "/" + ItemInfoID, item);

            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            item = await response.Content.ReadAsAsync<Item>();

            MessageBox.Show("Item with ID: " + ItemInfoID + " has been succesfully updated!");
            ((App)App.Current).ChangeUserControl(App.container.Resolve<ItemView>());

            return item;
        }

        /*
        * Made by Nicolaj
        * This function sets the field to the Selected item on the listview.
        */
        static public void setFields()
        {
            ItemInfoID = ItemPageViewModel.SelectedItem.FldItemInfoID;
            CategoryID = ItemPageViewModel.SelectedItem.FldCategoryTypeID;
            Name = ItemPageViewModel.SelectedItem.FldItemName;
            Description = ItemPageViewModel.SelectedItem.FldItemDescription;
            Price = ItemPageViewModel.SelectedItem.FldPrice;
            Image = ItemPageViewModel.SelectedItem.FldImage;
        }

    }
    }

