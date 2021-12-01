﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;
using CanteenManagement.ViewModels;

namespace CanteenManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Using Unity Container i can change views without having to new a viewmodel each time
        /// so i dont loose a instance all time.
        /// </summary>
        public static IUnityContainer container = new UnityContainer();
        /// <summary>
        /// My content control, i bind this to the content control in the mainview, and then i can change
        /// the view in the content
        /// </summary>
        public ContentControl ContentControlRef { get; set; } = null;

        public App()
        {
            container.RegisterSingleton<IHomePageViewModel, HomePageViewModel>();
            container.RegisterSingleton<ICreatePageViewModel, CreatePageViewModel>();
            container.RegisterSingleton<IItemPageViewModel, ItemPageViewModel>();
            container.RegisterSingleton<IUpdateItemPageViewModel, UpdateItemPageViewModel>();
            container.RegisterSingleton<ILunchPageViewModel, LunchPageViewModel>();
        }

        /// <summary>
        /// this is my method for changing the view.
        /// </summary>
        /// <param name="view"></param>
        public void ChangeUserControl(UserControl view)
        {
            this.ContentControlRef.Content = view;
        }
    }
}
