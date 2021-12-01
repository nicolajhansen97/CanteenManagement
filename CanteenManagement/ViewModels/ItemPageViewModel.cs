﻿using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    public class ItemPageViewModel : Bindable, IItemPageViewModel
    {
        private ObservableCollection<ItemModel> itemList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> ItemList
        {
            get { return itemList; }
            set { itemList = value; propertyIsChanged(); }
        }
        public ICommand ChangePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }
        public ICommand ChangeToCreatePageCMD { get; set; }
        public ICommand ChangeToUpdateItemPageCMD { get; set; }
        public ICommand DeleteItemCMD { get; set; }

        public ItemPageViewModel()
        {

            ChangePageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

            ChangeToCreatePageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<CreatePageView>());
            });


            ChangeToUpdateItemPageCMD = new RelayCommand(() => {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<UpdateItemView>());
            });

            DeleteItemCMD = new RelayCommand(() => {
                DeleteItem();
            });


            //Calls it first time you open the View, so you get all the items.
            getProducts();
        }

        public class Item
        {
            public int fldItemInfoID { get; set; }
            public int fldCategoryTypeID { get; set; }
            public string fldItemName { get; set; }
            public string fldItemDescription { get; set; }
            public double fldPrice { get; set; }
            public string fldImage { get; set; }
        }

        /*
        Made by Nicolaj

        This task will always clear the list first, as its also is used when deleting items etc.
        It calls the API and the response is JSON of all the items in the database. This is Deserialized and added to the ObservableCollection
        */
        async Task getProducts()
        {
            try
            {
                ItemList.Clear();

                HttpResponseMessage response = await ApiHelper.client.GetAsync(ApiHelper.serverUrl + ApiHelper.getItems);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<List<Item>>(responseBody);
                items.ForEach((i) => ItemList.Add(CreateItem(i)));
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /*
        Made by Nicolaj

        Creates a ItemModel and gives the values from the Item. Then it returns the ItemModel.
        This is used to fill the ObservableCollection as this is a collection of ItemModel.
        */
        private ItemModel CreateItem(Item i)
        {
            ItemModel im = new ItemModel()
            {
                Item = i
                
            };

            im.Category = i.fldCategoryTypeID;
            im.Name = i.fldItemName;
            im.Description = i.fldItemDescription;
            im.Price = i.fldPrice;
            im.Picture = i.fldImage;
            im.ItemID = i.fldItemInfoID;

            return im;
        }



        /*
        Made by Nicolaj

        The following code is using the HttpResponseMessage and connects to the HTTP client which calls DeleteAsync who takes the URI as parameter.
        This works like you make a Delete action with example Postman. The deleted product is decided from the Items ID.
        */
        static async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            HttpResponseMessage response = await ApiHelper.client.DeleteAsync(
                ApiHelper.serverUrl + ApiHelper.getItems+"/17");
            return response.StatusCode;
        }

        /*
        Made by Nicolaj

        Calling the DeleteProductAsync task with the ID. After this getProducts() is called which is used to refresh the ListView through the ObservableCollection.
        */
        async Task DeleteItem()
        {
            try
            {
                var statusCode = await DeleteProductAsync(18);
                MessageBox.Show($"Deleted (HTTP Status = {(int)statusCode})");
                getProducts();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}