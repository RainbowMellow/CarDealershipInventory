﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealershipInventory.Core.ApplicationServices;
using CarDealershipInventory.Core.Entity;
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
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            return Ok(_carService.GetAllCars());
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            return Ok(_carService.GetCarById(id));
        }

        // POST api/<CarsController>
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            return Ok();
            //_carService.CreateCar(car)
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
