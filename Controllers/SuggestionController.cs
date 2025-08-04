using FoodSuggestionWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace FoodSuggestionWebApp.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEngine;

        public SuggestionController(PredictionEnginePool<ModelInput, ModelOutput> predictionEngine)
        {
            _predictionEngine = predictionEngine;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ModelInput input)
        {
            var prediction = _predictionEngine.Predict(input);
            ViewBag.Suggestion = prediction.PredictedLabel;
            return View(input);
        }
    }
}
