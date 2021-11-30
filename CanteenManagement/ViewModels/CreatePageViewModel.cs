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
    public class CreatePageViewModel : Bindable, ICreatePageViewModel
    {

        public ICommand ChangePageCMD { get; set; }
        public ICommand CloseProgramCMD { get; set; }
        public ICommand CreateProductCMD { get; set; }


        public CreatePageViewModel()
        {

            ChangePageCMD = new RelayCommand(() =>
            {
                ((App)App.Current).ChangeUserControl(App.container.Resolve<HomePageView>());
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

        async Task createItem()
        {
            try
            {
                HttpResponseMessage response = await ApiHelper.client.GetAsync(ApiHelper.serverUrl + ApiHelper.getItems);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<List<ItemModel>>(responseBody);



                // items.ForEach((i) => ItemList.Add((i)));
                //ItemList.Add(AddItem(items.Name, items.Description, items.Price, items.Category, items.Picture));


                MessageBox.Show(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


    }
    }

