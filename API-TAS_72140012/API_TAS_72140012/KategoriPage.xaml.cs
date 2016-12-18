using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using API_TAS_72140012.ViewModels;
using API_TAS_72140012.Models;


namespace API_TAS_72140012
{
    public partial class KategoriPage : ContentPage
    {
        private KategoriViewModel kategoriViewModel;
        public KategoriPage()
        {
            InitializeComponent();

            kategoriViewModel = new KategoriViewModel();
            listKategori.ItemTapped += ListKategori_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }

        private void ListKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Kategori item = (Kategori)e.Item;
            EditKategoriPage editPage = new EditKategoriPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            var tambahPage = new TambahKategoriPage(kategoriViewModel.ListKategori);
            tambahPage.BindingContext = new Kategori();
            await Navigation.PushAsync(tambahPage);
        }
    }
}
  
