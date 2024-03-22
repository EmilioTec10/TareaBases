using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace App1
{
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<ItemMenu> Platos { get; set; }
        public ObservableCollection<ItemMenu> Bebidas { get; set; }
        public ObservableCollection<ItemMenu> Ensaladas { get; set; }
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
                new ItemMenu { Nombre = "Plato 3", Precio = 9.75 }
            };

            Bebidas = new ObservableCollection<ItemMenu>
            {
                new ItemMenu { Nombre = "Bebida 1", Precio = 2.99 },
                new ItemMenu { Nombre = "Bebida 2", Precio = 3.50 }
            };

            Ensaladas = new ObservableCollection<ItemMenu>
            {
                new ItemMenu { Nombre = "Ensalada 1", Precio = 7.99 },
                new ItemMenu { Nombre = "Ensalada 2", Precio = 6.50 }
            };

            // Asignar las listas al ListView
            PlatosListView.ItemsSource = Platos;
            BebidasListView.ItemsSource = Bebidas;
            EnsaladasListView.ItemsSource = Ensaladas;
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
                item.Cantidad--;
        }

        void OnIncreaseClicked(object sender, EventArgs e)
        {
            var item = (ItemMenu)((Button)sender).CommandParameter;
            item.Cantidad++;
        }

        void OnFinalizarPedidoClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para finalizar el pedido
            // Por ejemplo, enviar el pedido a un servidor, guardar en una base de datos, etc.
            // En este ejemplo, solo mostraremos un mensaje de confirmación

            DisplayAlert("Pedido Finalizado", "¡Gracias por su pedido!", "OK");
            // Limpiar el carrito después de finalizar el pedido
            Carrito.Clear();
        }
    }
}
