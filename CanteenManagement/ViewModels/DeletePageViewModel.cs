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
            int fldItemInfoID { get; set; }
            int fldCategoryTypeID { get; set; }
            string fldItemName { get; set; }
            string fldItemDescription { get; set; }
            double fldPrice { get; set; }
           
            string fldImage { get; set; }
        }
        async Task getProducts()
        {
            try
            {
                HttpResponseMessage response = await ApiHelper.client.GetAsync(ApiHelper.serverUrl + ApiHelper.getItems);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<List<Item>>(responseBody);
                items.ForEach((i) => ItemList.Add(CreateItem(i)));

                //MessageBox.Show(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private ItemModel CreateItem(Item i)
        {
            ItemModel im = new ItemModel()
            {
                Item = i
            };

            MessageBox.Show(im.Name);
            return im;
        }
    }
}