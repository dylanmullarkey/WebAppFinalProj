using WebAppFinalProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAppFinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCarController : ControllerBase
    {
        private readonly UserInfoContext _userInfoContext;

        public FavoriteCarController(UserInfoContext userInfoContext)
        {
            _userInfoContext = userInfoContext;
        }

        // Get all cars
        [HttpGet]
        [Route("GetCars")]
        public IActionResult GetCars()
        {
            var cars = _userInfoContext.FavoriteCars.ToList();
            if (cars == null || !cars.Any())
            {
                return NotFound("No cars found.");
            }
            return Ok(cars);
        }

        // Get a specific car or return first 5 if null
        [HttpGet]
        [Route("GetFirstFiveCars")]
        public IActionResult GetFavoriteCar(int? id)
        {
            if (id == null || id == 0)
            {
                var cars = _userInfoContext.FavoriteCars.Take(5).ToList();
                return Ok(cars);
            }

            var car = _userInfoContext.FavoriteCars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            return Ok(car);
        }

        // Add a new car
        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar([FromBody] FavoriteCar favoriteCar)
        {
            if (favoriteCar == null)
            {
                return BadRequest("Car data is missing.");
            }

            _userInfoContext.FavoriteCars.Add(favoriteCar);
            _userInfoContext.SaveChanges();
            return CreatedAtAction(nameof(GetFavoriteCar), new { id = favoriteCar.Id }, favoriteCar);
        }

        // Update an existing car
        [HttpPut]
        [Route("UpdateCar")]
        public IActionResult UpdateCar([FromBody] FavoriteCar favoriteCar)
        {
            if (favoriteCar == null)
            {
                return BadRequest("Car data is missing.");
            }

            var existingCar = _userInfoContext.FavoriteCars.FirstOrDefault(x => x.Id == favoriteCar.Id);
            if (existingCar == null)
            {
                return NotFound("Car not found.");
            }

            _userInfoContext.Entry(favoriteCar).State = EntityState.Modified;
            _userInfoContext.SaveChanges();
            return NoContent();
        }

        // Delete a car
        [HttpDelete]
        [Route("DeleteCar")]
        public IActionResult DeleteCar([FromBody] FavoriteCar favoriteCar)
        {
            if (favoriteCar == null || favoriteCar.Id == 0)
            {
                return BadRequest("Car data is missing or invalid.");
            }

            var existingCar = _userInfoContext.FavoriteCars.FirstOrDefault(x => x.Id == favoriteCar.Id);
            if (existingCar == null)
            {
                return NotFound("Car not found.");
            }

            _userInfoContext.FavoriteCars.Remove(existingCar);
            _userInfoContext.SaveChanges();
            return NoContent();
        }
    }
}
