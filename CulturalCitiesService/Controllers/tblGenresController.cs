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
    builder.EntitySet<tblGenre>("tblGenres");
    builder.EntitySet<tblEvent>("tblEvent"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblGenresController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblGenres
        [EnableQuery]
        public IQueryable<tblGenre> GettblGenres()
        {
            return db.tblGenre;
        }

        // GET: odata/tblGenres(5)
        [EnableQuery]
        public SingleResult<tblGenre> GettblGenre([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblGenre.Where(tblGenre => tblGenre.genre_id == key));
        }

        // PUT: odata/tblGenres(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblGenre> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblGenre tblGenre = await db.tblGenre.FindAsync(key);
            if (tblGenre == null)
            {
                return NotFound();
            }

            patch.Put(tblGenre);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGenreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblGenre);
        }

        // POST: odata/tblGenres
        public async Task<IHttpActionResult> Post(tblGenre tblGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblGenre.Add(tblGenre);
            await db.SaveChangesAsync();

            return Created(tblGenre);
        }

        // PATCH: odata/tblGenres(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblGenre> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblGenre tblGenre = await db.tblGenre.FindAsync(key);
            if (tblGenre == null)
            {
                return NotFound();
            }

            patch.Patch(tblGenre);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblGenreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblGenre);
        }

        // DELETE: odata/tblGenres(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblGenre tblGenre = await db.tblGenre.FindAsync(key);
            if (tblGenre == null)
            {
                return NotFound();
            }

            db.tblGenre.Remove(tblGenre);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblGenres(5)/tblEvent
        [EnableQuery]
        public IQueryable<tblEvent> GettblEvent([FromODataUri] int key)
        {
            return db.tblGenre.Where(m => m.genre_id == key).SelectMany(m => m.tblEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblGenreExists(int key)
        {
            return db.tblGenre.Count(e => e.genre_id == key) > 0;
        }
    }
}
