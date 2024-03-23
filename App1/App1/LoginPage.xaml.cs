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

            // Realizar la lógica de inicio de sesión
            if (correo == "mrr" && contrasena == "2197")
            {
                // Si las credenciales son correctas, navegar a la página de menú
                await Navigation.PushAsync(new MenuPage());
            }
            else
            {
                // Si las credenciales son incorrectas, mostrar un mensaje de error
                await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navegar a la página de registro (aquí debes implementar esta página)
            await Navigation.PushAsync(new RegistroPage());
        }
    }
}
