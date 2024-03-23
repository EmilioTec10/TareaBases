using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RestTecAPI.Entities;

namespace RestTecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private Admin admin;

        public AdminController()
        {
            admin = new Admin();
        }

        // Method that uses the POST request to register an admin
        [HttpPost("register")]
        public IActionResult Register(string email, string password)
        {
            admin.register(email, password);
            return Ok("Admin registered successfully");
        }

        // Method that uses the POST request to log in as a user
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            bool isAdmin = admin.login(email, password);
            if (isAdmin)
                return Ok("Login successful");
            else
                return BadRequest("Incorrect email or password");
        }

        // Method that uses the POST request to create a new plate
        [HttpPost("plates/create")]
        public IActionResult CreatePlate(string name, string description)
        {
            admin.create_plate(name, description);
            return Ok("Plate created successfully");
        }

        // Method that uses the PUT request to update the name of a plate
        [HttpPut("plates/{id}/update/name")]
        public IActionResult UpdatePlateName(int id, string newName)
        {
            Plate plate = admin.GetPlateAtIndex(admin.plates, id); // Creates a plate object which will be the one found in the list of plates by index
            admin.update_plate_name(plate, newName);
            return Ok("Plate name updated successfully");
        }


        // Similar methods for other plate updates

        // Implement methods for other Admin actions

        // You can add more methods as needed to handle different Admin actions

        // Example:
        // [HttpGet("most-sell")]
        // public IActionResult See10MostSell()
        // {
        //     admin.see_10_most_sell();
        //     return Ok("10 most sold plates retrieved successfully");
        // }
    }
}
