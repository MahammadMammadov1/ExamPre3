using ExamPre3.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamPre3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDb;

        public HomeController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            var trainers = _appDb.Services.ToList();
            return View(trainers);
        }
        
    }
}