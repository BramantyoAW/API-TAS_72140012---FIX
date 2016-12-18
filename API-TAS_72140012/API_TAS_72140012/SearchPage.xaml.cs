using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using API_TAS_72140012.ViewModels;
using API_TAS_72140012.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;


namespace API_TAS_72140012
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            //btnSearchBarang.Clicked += btnSearchBarang_Clicked;
            //btnSearchKategori.Clicked += btnSearchKategori_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModel();
        }

        //private void btnSearchBarang_Clicked(object sender, EventArgs e)
        //{
        //    this.BindingContext = new SearchKategori(txtSearchBar.Text);
        //    txtSearchBar.Text = null;
        //}

        //private void btnSearchKategori_Clicked(object sender, EventArgs e)
        //{
        //    this.BindingContext = new SearchBarang(txtSearchKat.Text);
        //    txtSearchKat.Text = null;
        //}
    }
}