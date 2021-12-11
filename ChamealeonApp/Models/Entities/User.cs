using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamealeonApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ChamealeonApp.Models.Entities
{
    public class User : IdentityUser
    {
        //Burhan
        //no Id because Identity creates it by default
        // public Guid Id { get; set; }
        public string Name { get; set; } //required
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; } //metric or imperial?
        public double Height { get; set; } //metric or imperial?
        public NutritionalInformation PersonalNutritionalInformationGoal { get; set; } //personal goals
        public MealPlan CurrentMealPlan { get; set; }
        public List<Meal> UserCreatedMeals { get; set; }
    }
}

