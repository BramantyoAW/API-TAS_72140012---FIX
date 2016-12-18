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
    public partial class TambahJenisMotorPage : ContentPage
    {
        public TambahJenisMotorPage()
        {
            InitializeComponent();
            btnTambahJenisMotor.Clicked += BtnTambahJenisMotor_Clicked;
        }

        private RestClient _client = 
            new RestClient("http://72140012stok.azurewebsites.net/");

        private async void BtnTambahJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.POST);
            var newJenisMotor = new JenisMotor
            { NamaJenisMotor = txtNamaJenisMotor.Text,
                NamaMerk = txtNamaMerek.Text
            };
            _request.AddBody(newJenisMotor);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new JenisMotorPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Erorr : " + ex.Message, "");
            }
        }
    }
}
