using Microsoft.AspNetCore.Mvc;
using RMS.Domain.Entities;
using RMS.Infrastructure.Data;

namespace RMS.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var villaList = _db.Villas.ToList();
            return View(villaList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name.Length < 2)
            {
                ModelState.AddModelError("name", "Name lenght must be greater than one");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            // Ways to retrieve in EF Core
            Villa? ob = _db.Villas.FirstOrDefault(x => x.Id == id);
            if(ob == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(ob);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
