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
            _db.Villas.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
