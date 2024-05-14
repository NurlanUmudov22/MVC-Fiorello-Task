using Fiorello_PB101.Services;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiorello_PB101.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISliderService _sliderService;
        private readonly IBlogService _blogService;
        private readonly IExpertsService _expertsService;
        public HomeController(ISliderService sliderService,
                               IBlogService blogService,
                               IExpertsService expertsService)
        {
            _sliderService = sliderService;
            _blogService = blogService;
            _expertsService = expertsService;

        }

        public async Task<IActionResult> Index()
        {
            HomeVM model = new()
            {
                Sliders = await _sliderService.GetAllAsync(),
                SliderInfo = await _sliderService.GetSliderInfoAsync(),
                Blogs = await _blogService.GetAllAsync(),
                Experts = await _expertsService.GetAllAsync(),
            };
            return View(model);  
        }
    }
}
