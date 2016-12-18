﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using API_TAS_72140012.ViewModels;
using API_TAS_72140012.Models;

namespace API_TAS_72140012
{
    public partial class JenisMotorPage : ContentPage
    {
        private JenisMotorViewModel jenisMotorViewModel;
        public JenisMotorPage()
        {
            InitializeComponent();

            jenisMotorViewModel = new JenisMotorViewModel();
            listJenisMotor.ItemTapped += ListJenisMotor_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new JenisMotorViewModel();
        }

        private void ListJenisMotor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            EditJenisMotorPage editPage = new EditJenisMotorPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahJenisMotorPage());
        }

    }
}

