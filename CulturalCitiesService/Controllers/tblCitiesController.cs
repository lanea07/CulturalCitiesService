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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CulturalCitiesService;

namespace CulturalCitiesService.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CulturalCitiesService;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<tblCity>("tblCities");
    builder.EntitySet<tblCountry>("tblCountry"); 
    builder.EntitySet<tblCustomer>("tblCustomer"); 
    builder.EntitySet<tblEvent>("tblEvent"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblCitiesController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblCities
        [EnableQuery]
        public IQueryable<tblCity> GettblCities()
        {
            return db.tblCity;
        }

        // GET: odata/tblCities(5)
        [EnableQuery]
        public SingleResult<tblCity> GettblCity([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCity.Where(tblCity => tblCity.city_id == key));
        }

        // PUT: odata/tblCities(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblCity> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCity tblCity = await db.tblCity.FindAsync(key);
            if (tblCity == null)
            {
                return NotFound();
            }

            patch.Put(tblCity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCity);
        }

        // POST: odata/tblCities
        public async Task<IHttpActionResult> Post(tblCity tblCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCity.Add(tblCity);
            await db.SaveChangesAsync();

            return Created(tblCity);
        }

        // PATCH: odata/tblCities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblCity> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCity tblCity = await db.tblCity.FindAsync(key);
            if (tblCity == null)
            {
                return NotFound();
            }

            patch.Patch(tblCity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCity);
        }

        // DELETE: odata/tblCities(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblCity tblCity = await db.tblCity.FindAsync(key);
            if (tblCity == null)
            {
                return NotFound();
            }

            db.tblCity.Remove(tblCity);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblCities(5)/tblCountry
        [EnableQuery]
        public SingleResult<tblCountry> GettblCountry([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCity.Where(m => m.city_id == key).Select(m => m.tblCountry));
        }

        // GET: odata/tblCities(5)/tblCustomer
        [EnableQuery]
        public IQueryable<tblCustomer> GettblCustomer([FromODataUri] int key)
        {
            return db.tblCity.Where(m => m.city_id == key).SelectMany(m => m.tblCustomer);
        }

        // GET: odata/tblCities(5)/tblEvent
        [EnableQuery]
        public IQueryable<tblEvent> GettblEvent([FromODataUri] int key)
        {
            return db.tblCity.Where(m => m.city_id == key).SelectMany(m => m.tblEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCityExists(int key)
        {
            return db.tblCity.Count(e => e.city_id == key) > 0;
        }
    }
}
