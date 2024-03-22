using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace App1
{
    public partial class CarritoPage : ContentPage
    {
        private ObservableCollection<ItemMenu> carrito;

        public CarritoPage(ObservableCollection<ItemMenu> carrito)
        {
            InitializeComponent();
            this.carrito = carrito;
            CarritoListView.ItemsSource = carrito;
            UpdateTotalPrice();
        }

        // Lógica para eliminar un elemento del carrito
        void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            carrito.Remove(item);
            UpdateTotalPrice();
        }

        // Lógica para disminuir la cantidad de un elemento del carrito
        // Lógica para disminuir la cantidad de un elemento del carrito
        void OnDecreaseClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            if (item.Cantidad > 0)
            {
                item.Cantidad--;
                if (item.Cantidad == 0)
                    carrito.Remove(item); // Eliminar el elemento si la cantidad llega a cero
                UpdateTotalPrice();
            }
        }

        // Lógica para aumentar la cantidad de un elemento del carrito
        void OnIncreaseClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            if (item.Cantidad < 5) // Limitar la cantidad máxima a 5
            {
                item.Cantidad++;
                UpdateTotalPrice();
            }
        }


        // Método para actualizar el monto total a pagar
        void UpdateTotalPrice()
        {
            double total = carrito.Sum(item => item.PrecioTotal);
            TotalAPagarLabel.Text = $"Total a Pagar: {total:C}";
        }
    }
}
