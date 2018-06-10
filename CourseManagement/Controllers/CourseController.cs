using CourseManagement.Models;
using CourseManagement.Repositories;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CourseManagement.Controllers
{
    public class CourseController : Controller
    {
        private CourseRepository _courseRepo;
        public CourseController()
        {
            _courseRepo = new CourseRepository();
        }
        public async Task<ActionResult> Index()
        {
            var rezult = new
            {
                Name = _courseRepo.GetCourses()
            };
            return View(await rezult.Name); ;
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name, Cost, CourseDateTime, Duration")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepo.Create(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rezult = await _courseRepo.GetEdit(id);
            if (rezult == null)
            {
                return HttpNotFound();
            }
            return View(rezult);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name, Cost, CourseDateTime, Duration")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepo.Edit(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id > 0)
            {
               await _courseRepo.Delete(id);
               return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}