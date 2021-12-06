using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChamealeonApp.Models.Entities;
using ChamealeonApp.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChamealeonApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MealController : Controller
    {
        private readonly DataContext _context;
        public MealController(DataContext context)
        {
            _context = context;
        }
        //Amir
        //POST add new user meal to db
        [HttpPost("{id}")]
        public async Task<IActionResult> AddCustomMealAsync(string id, [FromBody] Meal modelMeal)
        {
            // TODO depends on ef core implementation for now
            await Task.Yield();
            return Created("", null);
        }

        //PUT possibly
        // [HttpPut]
        // public async Task<IActionResult> UpdateMealAsync([FromBody] User modelUser)
        // {

        //     await Task.Yield();
        //     return Ok();
        // }

        //DELETE delete user meal?
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            //TODO: Implement Realistic Implementation
            await Task.Yield();
            return Ok();
        }
        //GET full details of a meal (screen, has instructions etc)
        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {

            await Task.Yield();
            return Ok();
        }
    }
}