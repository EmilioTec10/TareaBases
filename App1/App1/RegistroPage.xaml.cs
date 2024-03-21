using System;
using Xamarin.Forms;

namespace App1
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para guardar la información del usuario
            // Por ejemplo, puedes crear una instancia de la clase Usuario y asignar los valores de los campos de entrada de texto
            Usuario nuevoUsuario = new Usuario
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Direccion = txtDireccion.Text,
                // Debes convertir el texto de la fecha de nacimiento a un tipo DateTime
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                Telefono = txtTelefono.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                Password = txtContrasena.Text
            };

            // Aquí deberías guardar la información del nuevo usuario en tu sistema (por ejemplo, en una base de datos)
            // Luego, puedes mostrar un mensaje de éxito o navegar a otra página
            await DisplayAlert("Registrarse", "¡Registro exitoso!", "OK");
        }
    }
}
