using System;
using Xamarin.Forms;

namespace App1
{
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();

            // Agregar opciones al Picker
            calificacionPicker.Items.Add("1");
            calificacionPicker.Items.Add("2");
            calificacionPicker.Items.Add("3");
            calificacionPicker.Items.Add("4");
            calificacionPicker.Items.Add("5");
        }

        private async void EnviarFeedbackClicked(object sender, EventArgs e)
        {
            // Obtener la calificación seleccionada del Picker
            string calificacion = calificacionPicker.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(calificacion))
            {
                await DisplayAlert("Error", "Por favor, selecciona una calificación.", "OK");
                return;
            }

            // Crear una instancia de Feedback directamente aquí
            var feedback = new Feedback
            {
                Usuario = "Usuario Ejemplo",
                Fecha = DateTime.Now,
                Calificacion = calificacion
            };

            await DisplayAlert("Éxito", "¡Gracias por tu feedback!", "OK");

            await Navigation.PopAsync();
        }

        // Definir la clase Feedback aquí dentro de la clase FeedbackPage
        public class Feedback
        {
            public string Usuario { get; set; }
            public DateTime Fecha { get; set; }
            public string Calificacion { get; set; } // Cambiar el tipo de int a string
        }
    }
}
