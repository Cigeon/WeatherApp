using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    public class HistoryController : ApiController
    {
        private IHistoryService historyRepo;

        public HistoryController(IHistoryService history)
        {
            historyRepo = history;
        }

        // GET: api/History
        public async Task<List<WeatherForecast>> GetForecastsAsync()
        {
            return await historyRepo.GetForecastsAsync();
        }

        // GET: api/History/5
        [ResponseType(typeof(WeatherForecast))]
        public async Task<IHttpActionResult> GetForecastAsync(int id)
        {
            var weatherForecast = await historyRepo.GetForecastByIdAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            return Ok(weatherForecast);
        }

        // PUT: api/History/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutForecastAsync(int id, WeatherForecast forecast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forecast.Id)
            {
                return BadRequest();
            }

            try
            {
                await historyRepo.EditForecastAsync(forecast);
            }
            catch (Exception)
            {
                if (!ForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/History
        [ResponseType(typeof(WeatherForecast))]
        public async Task<IHttpActionResult> PostForecastAsync(WeatherForecast forecast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (forecast == null)
            {
                return BadRequest();
            }

            try
            {
                await historyRepo.SaveForecastAsync(forecast);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return CreatedAtRoute("DefaultApi", new { id = forecast.Id }, forecast);
        }

        // DELETE: api/History/5
        [ResponseType(typeof(WeatherForecast))]
        public async Task<IHttpActionResult> DeleteForecastAsync(int id)
        {
            var forecast = await historyRepo.GetForecastByIdAsync(id);

            if (forecast == null)
            {
                return NotFound();
            }

            try
            {
                await historyRepo.DeleteForecastAsync(id);
            }
            catch (Exception)
            {
                if (!ForecastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    InternalServerError();
                }
            }

            return Ok(forecast);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                historyRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForecastExists(int id)
        {
            return historyRepo.GetForecastsAsync().Result.Count(e => e.Id == id) > 0;
        }
    }
}