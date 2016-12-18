using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using API_TAS_72140012.Models;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace API_TAS_72140012.ViewModels
{
    public class KategoriViewModel : BindableObject
    {
        private RestClient _client =
            new RestClient("http://72140012stok.azurewebsites.net/");

        private ObservableCollection<Kategori> listKategori;
        public ObservableCollection<Kategori> ListKategori
        {
            get { return listKategori; }
            set { listKategori = value; OnPropertyChanged("ListKategori"); }
        }

        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/Kategori", Method.GET);
            var _response = await _client.Execute<List<Kategori>>(_request);
            ListKategori = new ObservableCollection<Kategori>(_response.Data);
        }

        public KategoriViewModel()
        {
            RefreshDataAsync();
        }
    }
}
