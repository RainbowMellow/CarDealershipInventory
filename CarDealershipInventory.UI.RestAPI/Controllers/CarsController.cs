﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealershipInventory.Core.ApplicationServices;
using CarDealershipInventory.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealershipInventory.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }



        // GET: api/<CarsController>
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(_carService.GetAllCars());
            }
            catch (NullReferenceException e)
            {
                return StatusCode(404, e.Message);
            }
            
        }

        // GET api/<CarsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            try
            {
                return Ok(_carService.GetCarById(id));
            }
            catch (NullReferenceException e)
            {
                return StatusCode(404, e.Message);
            }
            
        }

        // POST api/<CarsController>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            try
            {
                return Ok(_carService.CreateCar(car));
            }
            catch (ArgumentException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<CarsController>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            try
            {
                return Ok(_carService.DeleteCar(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
