using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;


namespace MyApp.Services
{
    public class ClientApiService
    {
        private HttpClient client;
        private const string BaseUrl = "https://localhost:7202/api/client"; // URL base de tu API
        public ClientApiService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
        }

        // Método para registrar un nuevo cliente
        public async Task<bool> RegisterClientAsync(string name, string lastName, string address, string birthDate, int phones, string email, string password)
        {
            var httpClient = new HttpClient();

            // URL completa del endpoint de registro
            var url = $"{BaseUrl}/register";

            // Datos a enviar en el cuerpo de la solicitud
            var data = new { name, lastName, address, birthDate, phones, email, password };

            // Serializar los datos a formato JSON
            var json = JsonConvert.SerializeObject(data);

            // Crear contenido de la solicitud HTTP
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Hacer la solicitud POST a la API
            var response = await httpClient.PostAsync(url, content);

            // Verificar si la solicitud fue exitosa
            return response.IsSuccessStatusCode;
        }

        // Método para iniciar sesión como cliente
        public async Task<bool> LoginAsync(string email, string password)
        {
            var httpClient = new HttpClient();

            // URL completa del endpoint de inicio de sesión
            var url = $"{BaseUrl}/login";

            // Datos a enviar en el cuerpo de la solicitud
            var data = new { email, password };

            // Serializar los datos a formato JSON
            var json = JsonConvert.SerializeObject(data);

            // Crear contenido de la solicitud HTTP
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Hacer la solicitud POST a la API
            var response = await httpClient.PostAsync(url, content);

            // Verificar si la solicitud fue exitosa
            return response.IsSuccessStatusCode;
        }

        public async Task<string> CreateCart()
        {
            var response = await client.PostAsync("cart/create", null);

            if (response.IsSuccessStatusCode)
            {
                return "Shopping cart created successfully";
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return errorMessage;
            }
        }

        public async Task<string> AddToCart(int id, int quantity)
        {
            var payload = new
            {
                id = id,
                quantity = quantity
            };

            var response = await client.PostAsJsonAsync("cart/add", payload);

            if (response.IsSuccessStatusCode)
            {
                return "Plate added to cart successfully";
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return errorMessage;
            }
        }

        public async Task<string> ModifyQuantity(int id, int newQuantity)
        {
            var payload = new
            {
                id = id,
                new_quantity = newQuantity
            };

            var response = await client.PutAsJsonAsync($"cart/{id}/modify-quantity", payload);

            if (response.IsSuccessStatusCode)
            {
                return "Plate quantity modified successfully";
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return errorMessage;
            }
        }

        public async Task<string> RemoveFromCart(int id)
        {
            var response = await client.DeleteAsync($"cart/{id}/remove");

            if (response.IsSuccessStatusCode)
            {
                return "Plate removed from cart successfully";
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return errorMessage;
            }
        }
    }
}
