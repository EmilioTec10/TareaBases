using System;
using Xamarin.Forms;

namespace App1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Obtener el correo electrónico y la contraseña ingresados por el usuario
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;

            // Realizar la lógica de inicio de sesión aquí (puede variar según tus necesidades)
            // Por ejemplo, puedes validar las credenciales en una base de datos o archivo
            // En este ejemplo, simplemente mostraremos un mensaje de alerta
            await DisplayAlert("Iniciar Sesión", $"Correo: {correo}, Contraseña: {contrasena}", "OK");
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navegar a la página de registro (aquí debes implementar esta página)
            await Navigation.PushAsync(new RegistroPage());
        }
    }
}
