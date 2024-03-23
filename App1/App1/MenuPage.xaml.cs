using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace App1
{
    public partial class MenuPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double totalAPagar;
        public double TotalAPagar
        {
            get { return totalAPagar; }
            set
            {
                if (totalAPagar != value)
                {
                    totalAPagar = value;
                    OnPropertyChanged(nameof(TotalAPagar));
                }
            }
        }

        public ObservableCollection<ItemMenu> Platos { get; set; }

        public ObservableCollection<ItemMenu> Carrito { get; set; }

        public MenuPage()
        {
            InitializeComponent();
            InitializeMenuItems();
            Carrito = new ObservableCollection<ItemMenu>();
            BindingContext = this;
        }

        void InitializeMenuItems()
        {
            // Simulación de datos del menú
            Platos = new ObservableCollection<ItemMenu>
            {
                new ItemMenu { Nombre = "Plato 1", Precio = 10.99 },
                new ItemMenu { Nombre = "Plato 2", Precio = 12.50 },
                new ItemMenu { Nombre = "Plato 3", Precio = 9.75 },
                new ItemMenu { Nombre = "Bebida 1", Precio = 2.99 },
                new ItemMenu { Nombre = "Bebida 2", Precio = 3.50 },
                new ItemMenu { Nombre = "Ensalada 1", Precio = 7.99 },
                new ItemMenu { Nombre = "Ensalada 2", Precio = 6.50 }
            };

            // Asignar las listas al ListView
            PlatosListView.ItemsSource = Platos;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var itemSeleccionado = e.SelectedItem as ItemMenu;

            // Verificar si el item ya está en el carrito
            var itemExistente = Carrito.FirstOrDefault(i => i.Nombre == itemSeleccionado.Nombre);

            if (itemExistente != null)
            {
                // Si ya existe, incrementar la cantidad
                itemExistente.Cantidad++;
            }
            else
            {
                // Si no existe, agregarlo al carrito con cantidad 1
                itemSeleccionado.Cantidad = 1;
                Carrito.Add(itemSeleccionado);
            }

            // Limpiar la selección del ListView
            ((ListView)sender).SelectedItem = null;
        }

        void OnDecreaseClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            if (item.Cantidad > 0)
            {
                item.Cantidad--;
                UpdateTotalPrice();

                if (item.Cantidad == 0)
                {
                    Carrito.Remove(item);
                }
            }
        }

        void OnIncreaseClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            if (item.Cantidad < 5) // Limitar la cantidad máxima a 5
            {
                item.Cantidad++;
                UpdateTotalPrice();
            }
        }

        void UpdateTotalPrice()
        {
            TotalAPagar = Carrito.Sum(item => item.PrecioTotal);
        }

        void OnFinalizarPedidoClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para finalizar el pedido
            // Por ejemplo, enviar el pedido a un servidor, guardar en una base de datos, etc.
            // En este ejemplo, solo mostraremos un mensaje de confirmación

            //DisplayAlert("Pedido Finalizado", "¡Gracias por su pedido!", "OK");
            // Navegar a la página del carrito después de finalizar el pedido
            Navigation.PushAsync(new CarritoPage(Carrito));
            // Limpiar el carrito después de finalizar el pedido
            //Carrito.Clear();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
