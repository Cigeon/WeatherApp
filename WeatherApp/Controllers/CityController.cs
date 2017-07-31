using System.Net;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class CityController : Controller
    {
        private ICityService cityService;

        public CityController(ICityService city)
        {
            // Get service from Ninject
            cityService = city;
        }

        // GET: City
        public ActionResult Index()
        {
            return View(cityService.GetCitiesAsync().Result);
        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            SelectedCity selectedCity = cityService.GetCityByIdAsync(id).Result;

            if (selectedCity == null)
                return HttpNotFound();
            
            return View(selectedCity);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Value")] SelectedCity selectedCity)
        {
            if (ModelState.IsValid)
            {                
                // Save created city to repository
                cityService.AddCityAsync(selectedCity).Wait();

                return RedirectToAction("Index");
            }

            return View(selectedCity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            SelectedCity selectedCity = cityService.GetCityByIdAsync(id).Result;

            if (selectedCity == null)
                return HttpNotFound();
            
            return View(selectedCity);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Value")] SelectedCity selectedCity)
        {
            if (ModelState.IsValid)
            {
                // Save modified city to repository
                cityService.EditCityAsync(selectedCity).Wait();

                return RedirectToAction("Index");
            }
            return View(selectedCity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            SelectedCity selectedCity = cityService.GetCityByIdAsync(id).Result;
            if (selectedCity == null)
                return HttpNotFound();
            
            return View(selectedCity);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cityService.DeleteCityAsync(id).Wait();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cityService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
