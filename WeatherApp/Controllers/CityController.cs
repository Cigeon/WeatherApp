using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class CityController : Controller
    {
        //private WeatherContext db = new WeatherContext();
        private Repository repo = new Repository();

        // GET: City
        public ActionResult Index()
        {
            //return View(db.SelectedCities.ToList());
            return View(repo.GetCitiesList());

        }

        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCity selectedCity = repo.GetCityById(id);
            if (selectedCity == null)
            {
                return HttpNotFound();
            }
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
                // Copy city name to value
                var city = selectedCity;
                city.Value = city.Text;
                // Save created city to repository
                repo.AddCity(city);

                return RedirectToAction("Index");
            }

            return View(selectedCity);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCity selectedCity = repo.GetCityById(id);
            if (selectedCity == null)
            {
                return HttpNotFound();
            }
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
                // Copy city name to value
                var city = selectedCity;
                city.Value = city.Text;
                // Save modified city to repository
                repo.EditCity(city);

                return RedirectToAction("Index");
            }
            return View(selectedCity);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectedCity selectedCity = repo.GetCityById(id);
            if (selectedCity == null)
            {
                return HttpNotFound();
            }
            return View(selectedCity);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteCity(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
