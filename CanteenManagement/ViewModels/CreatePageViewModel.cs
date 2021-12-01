using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{

    //Made by Nicolaj
    //Model class used to create the item
    public class Item
    {
        public int fldCategoryTypeID { get; set; }
        public string fldItemName { get; set; }
        public string fldItemDescription { get; set; }
        public double fldPrice { get; set; }
        public string fldImage { get; set; }
    }

    public class CreatePageViewModel : Bindable, ICreatePageViewModel
    {

        public ICommand ChangeToItemPageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }
        public ICommand CreateProductCMD { get; set; }

        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }


        public CreatePageViewModel()
        {

            ChangeToItemPageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<ItemView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            CreateProductCMD = new RelayCommand(() =>
            {
                createItem();
            });

        }

        //Made by Nicolaj
        //Creates a new item which is used to create a product through the API
        public async Task createItem()
        {
            try
            {
         
                Item item = new Item
                {
     
                    fldCategoryTypeID = CategoryID,
                    fldItemName = ItemName,
                    fldItemDescription = ItemDescription,
                    fldPrice = Price,
                    fldImage = Image
                };


                var url = await CreateProductAsync(item);
                MessageBox.Show($"Created at {url}");

                
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //Made by Nicolaj
            //Creates the item with parameter item from the other function and calls the API to create the item.
            static async Task<Uri> CreateProductAsync(Item item)
            {
                HttpResponseMessage response = await ApiHelper.client.PostAsJsonAsync(
                ApiHelper.serverUrl + ApiHelper.getItems, item);
                response.EnsureSuccessStatusCode();

                ((App)App.Current).ChangeUserControl(App.container.Resolve<ItemView>());
                // return URI of the created resource.
                return response.Headers.Location;

            }
        }
    }
}

    

