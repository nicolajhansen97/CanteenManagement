using CanteenManagement.Models;
using CanteenManagement.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CanteenManagement.ViewModels
{
    public class DeletePageViewModel : Bindable, IDeletePageViewModel
    {
        private ObservableCollection<ItemModel> itemList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> ItemList
        {
            get { return itemList; }
            set { itemList = value; propertyIsChanged(); }
        }
        public ICommand ChangePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }


        public DeletePageViewModel()
        {

            ChangePageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
            });

            CloseProgramCMD = new RelayCommand(() =>
            {
                System.Environment.Exit(1);
            });

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

        //Made by Nicolaj
        //Still need to fix ObservableCollection is empty :(
        async Task getProducts()
        {
            try
            {
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

        //Made by Nicolaj
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

            return im;
        }
    }
}