﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using API_TAS_72140012.Models;
using API_TAS_72140012.ViewModels;

namespace API_TAS_72140012
{
    public partial class BarangPageNew : ContentPage
    {
        public BarangPageNew()
        {
            InitializeComponent();

            listBarang.ItemTapped += ListBarang_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
            btnSearch.Clicked += BtnSearch_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModel();
        }
        
        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            EditBarangPage editPage = new EditBarangPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahBarangPage());
        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

    }
}