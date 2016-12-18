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
   public class SearchBarang : BindableObject
    {
        private RestClient _client =
           new RestClient("http://72140012stok.azurewebsites.net/");

        private ObservableCollection<Barang> listBarangVM;
        public ObservableCollection<Barang> ListBarangVM
        {
            get { return listBarangVM; }
            set { listBarangVM = value; OnPropertyChanged("ListBarangVM"); }
        }

        private async void RefreshDataAsync(string NamaKategori)
        {
            RestRequest _request = new RestRequest("api/barang/?namaKategori=" + NamaKategori, Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarangVM = new ObservableCollection<Barang>(_response.Data);
        }

        public SearchBarang(string NamaKategori)
        {
            RefreshDataAsync(NamaKategori);
        }
    }
}
