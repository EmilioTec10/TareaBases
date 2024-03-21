using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para iniciar sesión
            await DisplayAlert("Iniciar Sesión", "Implementa la lógica para iniciar sesión", "OK");
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para el registro
            await DisplayAlert("Registrarse", "Implementa la lógica para registrarse", "OK");
        }
    }
}
