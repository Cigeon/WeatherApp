using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService historyService;

        public HistoryController(IHistoryService history)
        {
            // Get sevice from Ninject
            historyService = history;
        }

        // GET: History
        public ActionResult Index()
        {
            return View(historyService.GetForecasts());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var forecast = historyService.GetForecastById(id);

            if (forecast == null)
                return HttpNotFound();

            return View(forecast);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var forecast = historyService.GetForecastById(id);

            if (forecast == null)
                return HttpNotFound();
            
            return View(forecast);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historyService.DeleteForecast(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                historyService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
