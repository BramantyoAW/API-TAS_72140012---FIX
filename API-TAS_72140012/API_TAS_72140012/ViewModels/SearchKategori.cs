using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using API_TAS_72140012.Models;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.Collections.ObjectModel;

namespace API_TAS_72140012.ViewModels
{
   public class SearchKategori : BindableObject
    {
        private RestClient _client =
            new RestClient("http://72140012stok.azurewebsites.net/");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        private async void RefreshDataAsync(string Nama)
        {
            RestRequest _request = new RestRequest("api/barang/?namaBarang=" + Nama, Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }

        public SearchKategori(string Nama)
        {
            RefreshDataAsync(Nama);
        }
    }
}

