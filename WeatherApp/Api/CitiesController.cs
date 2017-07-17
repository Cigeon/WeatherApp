using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Api
{
    public class CitiesController : ApiController
    {
        private ICityService cityRepo;

        public CitiesController(ICityService city)
        {
            cityRepo = city;
        }

        // GET: api/Cities
        public List<SelectedCity> GetCities()
        {
            return cityRepo.GetCities();
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(int id)
        {
            SelectedCity city = cityRepo.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(int id, SelectedCity city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }

            try
            {
                cityRepo.EditCity(city);
            }
            catch (Exception)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(SelectedCity city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (city == null)
            {
                return BadRequest();
            }

            try
            {
                cityRepo.AddCity(city);
            }
            catch (Exception)
            {
                return InternalServerError();
            }            

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(int id)
        {
            var city = cityRepo.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }

            try
            {
                cityRepo.DeleteCity(city.Id);
            }
            catch (Exception)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError();
                }
            }            

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cityRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return cityRepo.GetCities().Count(c => c.Id == id) > 0;
        }
    }
}