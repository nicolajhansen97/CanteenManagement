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

        public int fldItemID { get; set; }
        public class Item
        {
            public int fldCategoryTypeID { get; set; }
            public string fldItemName { get; set; }
            public string fldItemDescription { get; set; }
            public double fldPrice { get; set; }
            public string fldImage { get; set; }
        }

        //Made by Nicolaj and Monir
        // Not working yet, make descripton when working. <3
        static async Task UpdateItemRunAsync()
        {

            int fldItemID = 20;

            try
            {
                // Create a new Item
                Item item = new Item();


                // Update the product
                item.fldCategoryTypeID = 1;
                item.fldItemName = "Rettet";
                item.fldItemDescription = "VIRKER DET HER MON?";
                item.fldPrice = 69.69;
                item.fldImage = "DETVIRKER.COM";
                await UpdateProductAsync(item);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
 

        //Made by Nicolaj and Monir
        //Not working yet, make description when working <3
        static async Task<Item> UpdateProductAsync(Item item)
        {

            HttpResponseMessage response = await ApiHelper.client.PutAsJsonAsync(ApiHelper.serverUrl + ApiHelper.getItems + "/16", item);

            response.EnsureSuccessStatusCode();

           // // Deserialize the updated product from the response body.
            item = await response.Content.ReadAsAsync<Item>();

            return item;
        }


    }
    }

