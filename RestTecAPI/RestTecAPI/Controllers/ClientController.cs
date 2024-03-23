using Microsoft.AspNetCore.Mvc;
using RestTecAPI.Entities;
using System;

namespace RestTecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly Client client;

        public ClientController()
        {
            client = new Client();
        }

        //Method that uses the POST request to register a client
        [HttpPost("register")]
        public IActionResult Register(string name, string last_name, string address, string birth_date, int phones, string email, string password)
        {
            client.register(name, last_name, address, birth_date, phones, email, password);
            return Ok("Client registered successfully");
        }

        //Method that uses the POST request to login a client
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            bool is_resgistered_client = client.login(email, password);
            if (is_resgistered_client)
                return Ok("Login successful");
            else
                return BadRequest("Incorrect email or password");
        }
        //Method that uses a POST request to create a shopping cart
        [HttpPost("cart/create")]
        public IActionResult CreateCart()
        {
            client.create_cart();
            return Ok("Shopping cart created successfully");
        }

        //Method that uses a POST request to add a plate to the shopping cart
        [HttpPost("cart/add")]
        public IActionResult AddToCart(int id, int quantity)
        {
            bool added_to_cart = client.add_to_cart(id, quantity);
            if (added_to_cart)
            {
                return Ok("Plate added to cart successfully");
            }
            else
            {
                return BadRequest("The plate couldn't be added to the shopping cart");
            }
        }


        //Method that uses the GET request to get the cart plates
        [HttpGet("cart")]
        public IActionResult SeeCart()
        {
            LinkedList<Plate> cartPlates = client.see_cart();
            return Ok(cartPlates);
        }

        //Method that uses the PUT request to modify the quantitty of a plate
        [HttpPut("cart/{id}/modify-quantity")]
        public IActionResult ModifyQuantity(int id, int new_quantity)
        {
            client.modify_quantity(id, new_quantity);
            return Ok("Plate quantity modified successfully");
        }

        //Method that uses the DELETE request to remove a plate from the shoppping cart
        [HttpDelete("cart/{id}/remove")]
        public IActionResult RemoveFromCart(int id)
        {
            client.remove_from_cart(id);
            return Ok("Plate removed from cart successfully");
        }

        //Method that uses the POST request to generate an order
        [HttpPost("order/generate")]
        public IActionResult GenerateOrder()
        {
            client.generate_order();
            return Ok("Order generated successfully");
        }

        //Method that uses the GET request to get the state of the order
        [HttpGet("order/state")]
        public IActionResult SeeOrderState()
        {
            int orderState = client.see_state_order();
            return Ok(new { state = orderState });
        }

        //Method that uses the POST request to make a feedback to the order
        [HttpPost("feedback")]
        public IActionResult MakeFeedback(float rating)
        {
             client.make_feedback(rating);
             return Ok("Feedback submitted successfully");
         }
    }
}
