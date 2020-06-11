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
    builder.EntitySet<tblCountry>("tblCountries");
    builder.EntitySet<tblCity>("tblCity"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblCountriesController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblCountries
        [EnableQuery]
        public IQueryable<tblCountry> GettblCountries()
        {
            return db.tblCountry;
        }

        // GET: odata/tblCountries(5)
        [EnableQuery]
        public SingleResult<tblCountry> GettblCountry([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCountry.Where(tblCountry => tblCountry.country_id == key));
        }

        // PUT: odata/tblCountries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblCountry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCountry tblCountry = await db.tblCountry.FindAsync(key);
            if (tblCountry == null)
            {
                return NotFound();
            }

            patch.Put(tblCountry);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCountry);
        }

        // POST: odata/tblCountries
        public async Task<IHttpActionResult> Post(tblCountry tblCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCountry.Add(tblCountry);
            await db.SaveChangesAsync();

            return Created(tblCountry);
        }

        // PATCH: odata/tblCountries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblCountry> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCountry tblCountry = await db.tblCountry.FindAsync(key);
            if (tblCountry == null)
            {
                return NotFound();
            }

            patch.Patch(tblCountry);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCountry);
        }

        // DELETE: odata/tblCountries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblCountry tblCountry = await db.tblCountry.FindAsync(key);
            if (tblCountry == null)
            {
                return NotFound();
            }

            db.tblCountry.Remove(tblCountry);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblCountries(5)/tblCity
        [EnableQuery]
        public IQueryable<tblCity> GettblCity([FromODataUri] int key)
        {
            return db.tblCountry.Where(m => m.country_id == key).SelectMany(m => m.tblCity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCountryExists(int key)
        {
            return db.tblCountry.Count(e => e.country_id == key) > 0;
        }
    }
}
