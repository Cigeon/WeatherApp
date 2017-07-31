using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public async Task<List<SelectedCity>> GetCitiesAsync()
        {
            return await cityRepo.GetCitiesAsync();
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetCityAsync(int id)
        {
            SelectedCity city = await cityRepo.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCityAsync(int id, SelectedCity city)
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
                await cityRepo.EditCityAsync(city);
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
        public async Task<IHttpActionResult> PostCityAsync(SelectedCity city)
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
                await cityRepo.AddCityAsync(city);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCityAsync(int id)
        {
            var city = await cityRepo.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            try
            {
                await cityRepo.DeleteCityAsync(city.Id);
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
            return cityRepo.GetCitiesAsync().Result.Count(c => c.Id == id) > 0;
        }
    }
}