using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public List<WeatherForecast> GetForecasts()
        {
            return historyRepo.GetForecasts();
        }

        // GET: api/History/5
        [ResponseType(typeof(WeatherForecast))]
        public IHttpActionResult GetForecast(int id)
        {
            var weatherForecast = historyRepo.GetForecastById(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            return Ok(weatherForecast);
        }

        // PUT: api/History/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForecast(int id, WeatherForecast forecast)
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
                historyRepo.EditForecast(forecast);
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
        public IHttpActionResult PostForecast(WeatherForecast forecast)
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
                historyRepo.SaveForecast(forecast);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return CreatedAtRoute("DefaultApi", new { id = forecast.Id }, forecast);
        }

        // DELETE: api/History/5
        [ResponseType(typeof(WeatherForecast))]
        public IHttpActionResult DeleteForecast(int id)
        {
            var weatherForecast = historyRepo.GetForecastById(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            try
            {
                historyRepo.DeleteForecast(id);
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

            return Ok(weatherForecast);
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
            return historyRepo.GetForecasts().Count(e => e.Id == id) > 0;
        }
    }
}