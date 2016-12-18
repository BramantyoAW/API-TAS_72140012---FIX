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

           btnSearchBarhang.Clicked += btnSearchBarang_Clicked;
           btnSearchKathegori.Clicked += btnSearchKategori_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new SearchKategori("");
        }

        private void btnSearchBarang_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchKategori(txtSearchBarhang.Text);
            txtSearchBarhang.Text = null;
        }

        private void btnSearchKategori_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchBarang(txtSearchKathegori.Text);
            txtSearchKathegori.Text = null;
        }

        //private void btnSearchKategori_Clicked(object sender, EventArgs e)
        //{
        //    this.BindingContext = new SearchBarang(txtSearchKat.Text);
        //    txtSearchKat.Text = null;
        //}
    }
}