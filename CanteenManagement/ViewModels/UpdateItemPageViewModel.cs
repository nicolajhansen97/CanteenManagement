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
        public int ItemInfoID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

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

            //HOW THE FUCK YOU CALL THIS EVERYTIME YOU GO BACK TO THE WINDOW RASMUS?! OR NIELS
            setFields();
        }
       
        //Made by Nicolaj and Monir
        // Not working yet, make descripton when working. <3
         async Task UpdateItemRunAsync()
        {
            ItemModel item = new ItemModel();

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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
 

        //Made by Nicolaj and Monir
        //Not working yet, make description when working <3
         async Task<ItemModel> UpdateProductAsync(ItemModel item)
        {

            HttpResponseMessage response = await ApiHelper.client.PutAsJsonAsync(ApiHelper.serverUrl + ApiHelper.getItems + "/" + ItemInfoID, item);

            response.EnsureSuccessStatusCode();

           // // Deserialize the updated product from the response body.
            item = await response.Content.ReadAsAsync<ItemModel>();

            MessageBox.Show("Item with ID: " + ItemInfoID + " has been succesfully updated!");
            ((App)App.Current).ChangeUserControl(App.container.Resolve<ItemView>());

            return item;
        }

        private void setFields()
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

