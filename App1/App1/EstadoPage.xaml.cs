using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    public partial class EstadoPage : ContentPage
    {
        private ObservableCollection<ItemMenu> carrito;
        private DateTime horaDeInicio;
        private double tiempoTotal;

        public EstadoPage(ObservableCollection<ItemMenu> carrito)
        {
            InitializeComponent();
            this.carrito = carrito;
            horaDeInicio = DateTime.Now;

            // Calcular el tiempo total necesario para preparar todos los platos
            foreach (var item in carrito)
            {
                double tiempoEstimado = new Random().Next(1, 16) / 10.0; // Tiempo en minutos entre 0.1 y 1.5
                tiempoTotal += tiempoEstimado;

                // Mostrar cada plato y su tiempo estimado en la lista
                listaPlatos.Children.Add(new Label { Text = $"{item.Nombre} - Tiempo estimado: {tiempoEstimado} minutos" });

                // Crear una barra de progreso para cada plato
                ProgressBar progressBar = new ProgressBar
                {
                    ProgressColor = Color.Green,
                    Margin = new Thickness(0, 5)
                };
                listaPlatos.Children.Add(progressBar);

                // Iniciar un temporizador para actualizar la barra de progreso de cada plato
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    // Calcular el tiempo transcurrido desde el inicio
                    double tiempoTranscurrido = (DateTime.Now - horaDeInicio).TotalMinutes;

                    // Calcular el progreso actual para este plato
                    double progresoPlato = tiempoTranscurrido / tiempoEstimado;
                    if (progresoPlato > 1)
                        progresoPlato = 1; // Asegurarse de que el progreso no exceda el 100%

                    // Actualizar la barra de progreso del plato actual
                    progressBar.Progress = progresoPlato;

                    // Verificar si se ha completado el pedido
                    if (tiempoTranscurrido >= tiempoTotal)
                    {
                        // Mostrar el mensaje de pedido listo
                        pedidoListoLabel.IsVisible = true;

                        // Detener el temporizador
                        return false;
                    }

                    // Continuar el temporizador
                    return true;
                });
            }

            // Iniciar un temporizador para actualizar la barra de progreso total del pedido
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Calcular el tiempo transcurrido desde el inicio
                double tiempoTranscurrido = (DateTime.Now - horaDeInicio).TotalMinutes;

                // Calcular el progreso total del pedido
                double progresoTotal = tiempoTranscurrido / tiempoTotal;
                if (progresoTotal > 1)
                    progresoTotal = 1; // Asegurarse de que el progreso no exceda el 100%

                // Actualizar la barra de progreso total del pedido
                progresoPedido.Progress = progresoTotal;

                // Verificar si se ha completado el pedido
                if (tiempoTranscurrido >= tiempoTotal)
                {
                    // Mostrar el mensaje de pedido listo
                    pedidoListoLabel.IsVisible = true;

                    // Detener el temporizador
                    return false;
                }

                // Continuar el temporizador
                return true;
            });
        }
    }
}
