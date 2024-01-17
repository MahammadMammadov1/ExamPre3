using ExamPre3.Business.CustomExceptions.ServiceExceptions;
using ExamPre3.Business.Service.Interfaces;
using ExamPre3.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamPre3.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServiceController : Controller
    {
        private readonly IServicesService _service;

        public ServiceController(IServicesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var trainer = await _service.GetAllAsync();
            return View(trainer);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> Create(Services services)
        {
            if(!ModelState.IsValid) return  View(services);
            if(services.FormFile == null)
            {
                ModelState.AddModelError("FormFile","file must be download");
                return View();
            }
            try
            {
                await _service.CreateAsync(services);
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }



            catch (FileLengthException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();

            }
            

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var trainer = await _service.GetByIdAsync(id);
            if(trainer== null) return NoContent();
            return View(trainer);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Services services)
        {
            if (!ModelState.IsValid) return View(services);
            try
            {
                await _service.UpdateAsync(services);   
            }
            catch (ContentTypeException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();
            }



            catch (FileLengthException ex)
            {
                ModelState.AddModelError(ex.Prop, ex.Message);
                return View();

            }
            return RedirectToAction("Index");
        }


        
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
