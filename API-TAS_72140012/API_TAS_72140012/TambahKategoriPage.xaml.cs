using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using API_TAS_72140012.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.Collections.ObjectModel;

namespace API_TAS_72140012
{
    public partial class TambahKategoriPage : ContentPage
    {
        private ObservableCollection<Kategori> myList;
        public TambahKategoriPage(ObservableCollection<Kategori>myList)
        {
            InitializeComponent();
            //tambahan
            this.myList = myList;
            btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
        }

        private RestClient _client =
            new RestClient("http://72140012stok.azurewebsites.net/");

        private async void BtnTambahKategori_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Kategori", Method.POST);
            var newKategori = new Kategori { NamaKategori = txtNamaKategori.Text };
            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //tambahan
                    myList.Add(newKategori);
                    await Navigation.PushAsync(new KategoriPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
