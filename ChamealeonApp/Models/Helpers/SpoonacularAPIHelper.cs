using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ChamealeonApp.Models.Entities;
using RestSharp;
using MealRoot = ChamealeonApp.Models.DTOs.SpoonacularResonseDTOs.MealByIdDTOs.Root;
using MealPlanRoot = ChamealeonApp.Models.DTOs.SpoonacularResonseDTOs.GenerateMealPlanDTOs.Root;
using SearchRoot = ChamealeonApp.Models.DTOs.SpoonacularResonseDTOs.SearchForRecipeDTOs.Root; //Classes generated from: https://json2csharp.com/json-to-csharp

namespace ChamealeonApp.Models.Helpers
{
    public static class SpoonacularAPIHelper
    {

        private static IRestClient client;

        static SpoonacularAPIHelper()
        {
            client = new RestClient("https://api.spoonacular.com");
        }

        //amir
        //HELPER FUNC: GET full details of selected meal and save to db as a proper Meal object
        public static async Task<MealRoot> GetFullDetailsOfMeal(int id)
        {
            var request = new RestRequest($"recipes/{id}/information").AddParameter("includeNutrition", "true").AddParameter("apiKey", "eaa80ce8fa5c4a2fa1a3c6c875ef9bf5");
            var response = await client.GetAsync<MealRoot>(request);
            return response;
        }




        //GET full meal plan for the week request

        //Mike
        public static async Task<MealPlanRoot> GenerateMealPlanFromSpoonacularAsync(string diet, List<string> exclude, double cals = 2000)
        {

            var excludeItems = "";
            for (int i = 0; i < exclude.Count; i++)
            {
                if (i < exclude.Count - 1)
                {
                    excludeItems += $"{exclude[i]}, ";
                    continue;
                }
                excludeItems += $"{exclude[i]}";
            }

            var request = new RestRequest($"mealplanner/generate").AddParameter("apiKey", "eaa80ce8fa5c4a2fa1a3c6c875ef9bf5").AddParameter("exclude", excludeItems).AddParameter("targetCalories", cals.ToString());

            if (diet != null)
            {
                request.AddParameter("diet", diet);
            }

            var response = await client.GetAsync<MealPlanRoot>(request);
            return response;

        }


         //Mike
         //TODO: make 3 overloads
        public static async Task<SearchRoot> GetMealSuggestions(string query)
        {
            var request = new RestRequest($"recipes/complexSearch").AddParameter("number", 6).AddParameter("apiKey", "eaa80ce8fa5c4a2fa1a3c6c875ef9bf5").AddParameter("query", query).AddParameter("addRecipeNutrition", true);

            var response = await client.GetAsync<SearchRoot>(request);
            return response;

        }

        // public static async Task<SearchRoot> GetMealSuggestions(string query, string mealType)
        // {
        //     var request = new RestRequest($"recipes/complexSearch").AddParameter("number", 6).AddParameter("apiKey", "eaa80ce8fa5c4a2fa1a3c6c875ef9bf5").AddParameter("query", query).AddParameter("addRecipeNutrition", true);

        //     if (diet != null)
        //     {
        //         request.AddParameter("diet", diet);
        //     }
        //     if (mealType != null)
        //     {
        //         request.AddParameter("type", mealType);
        //     }

        //     var response = await client.GetAsync<SearchRoot>(request);
        //     return response;

        // }

        // public static async Task<SearchRoot> GetMealSuggestions(string query, string mealType, string diet)
        // {
        //     var request = new RestRequest($"recipes/complexSearch").AddParameter("number", 6).AddParameter("apiKey", "eaa80ce8fa5c4a2fa1a3c6c875ef9bf5").AddParameter("query", query).AddParameter("addRecipeNutrition", true);

        //     if (diet != null)
        //     {
        //         request.AddParameter("diet", diet);
        //     }
        //     if (mealType != null)
        //     {
        //         request.AddParameter("type", mealType);
        //     }

        //     var response = await client.GetAsync<SearchRoot>(request);
        //     return response;

        // }



    }
}