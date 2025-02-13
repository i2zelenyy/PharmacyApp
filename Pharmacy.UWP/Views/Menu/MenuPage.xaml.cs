﻿using Pharmacy.UWP.Views.Basket;
using Pharmacy.UWP.Views.Medicine;
using Pharmacy.UWP.Views.Profile;
using Pharmacy.UWP.Views.SignIn;
using Pharmacy.UWP.Views.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Pharmacy.UWP.Views.Menu
{
    public sealed partial class MenuPage : Page
    {
        List<object> data;
        object authorisedUser;

        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.SelectedItem = HomePageItem;           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            authorisedUser = e.Parameter;

            data = new List<object>();
            data.Add(authorisedUser);
            data.Add("parameter1");
        }

        // Tapped events fix the problem accuring when navigation goes through top-bottom menus --> it fixes selection problem
        private void HomePageItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = HomePageItem;
        }

        private void MedicinePageItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = MedicinePageItem;
        }

        private void BasketPageItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = BasketPageItem;
        }

        private void StoresPageItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = StoresPageItem;
        }
        private void ProfilePageItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = ProfilePageItem;
            frame.Navigate(typeof(ProfilePage), authorisedUser);
            Page_Header.Text = "Profile";
        }

        private void SignOutItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Menu.SelectedItem = SignOutItem;
        }

        private void Menu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem nvi = (NavigationViewItem)args.InvokedItemContainer;
            if (nvi != null)
            {
                switch (nvi.Tag)
                {
                    case "HomePage":
                        frame.Navigate(typeof(HomePage), authorisedUser);
                        Page_Header.Text = "Home";
                        break;
                    case "MedicinePage":
                        frame.Navigate(typeof(MedicinePage), data);
                        Page_Header.Text = "Medicine";
                        break;

                    case "BasketPage":
                        frame.Navigate(typeof(BasketPage), authorisedUser);
                        Page_Header.Text = "Basket";
                        break;

                    case "StoresPage":
                        frame.Navigate(typeof(StoresPage), data);
                        Page_Header.Text = "Stores";
                        break;
                }
            }
        }

        private void Menu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem nvi = (NavigationViewItem)args.SelectedItemContainer;
            if (nvi != null)
            {
                switch (nvi.Tag)
                {
                    case "HomePage":
                        frame.Navigate(typeof(HomePage), authorisedUser);
                        Page_Header.Text = "Home";
                        break;
                    case "MedicinePage":
                        frame.Navigate(typeof(MedicinePage), data);
                        Page_Header.Text = "Medicine";
                        break;

                    case "BasketPage":
                        frame.Navigate(typeof(BasketPage), authorisedUser);
                        Page_Header.Text = "Basket";
                        break;

                    case "StoresPage":
                        frame.Navigate(typeof(StoresPage), data);
                        Page_Header.Text = "Stores";
                        break;
                    case "ProfilePage":
                        frame.Navigate(typeof(ProfilePage), authorisedUser);
                        Page_Header.Text = "Profile";
                        break;
                    case "SignOut":
                        this.Frame.Navigate(typeof(SignInPage), authorisedUser);
                        break;
                }
            }
        }
    }
}
