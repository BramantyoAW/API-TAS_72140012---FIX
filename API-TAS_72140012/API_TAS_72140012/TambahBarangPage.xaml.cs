using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using API_TAS_72140012.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace API_TAS_72140012
{
    public partial class TambahBarangPage : ContentPage
    {
        public TambahBarangPage()
        {
            InitializeComponent();

            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }

        async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/barang", Method.POST);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                Nama = txtNama.Text,
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                Stok = Convert.ToInt32(txtStok.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaJual.Text),
                TanggalBeli = DateTime.Today
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }

        }
        private RestClient _client =
            new RestClient("http://72140012stok.azurewebsites.net/");
    }
}
