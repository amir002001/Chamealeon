namespace ChamealeonApp.Models.DTOs.SpoonacularResonseDTOs.GenerateMealPlanDTOs{ 

    public class Meal
    {
        public int id { get; set; }
        public string imageType { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
    }

}