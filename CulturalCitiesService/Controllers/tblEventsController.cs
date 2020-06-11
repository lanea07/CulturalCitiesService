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
    builder.EntitySet<tblEvent>("tblEvents");
    builder.EntitySet<tblArtist>("tblArtist"); 
    builder.EntitySet<tblCity>("tblCity"); 
    builder.EntitySet<tblCulturalJobTasks>("tblCulturalJobTasks"); 
    builder.EntitySet<tblCustomerEvent>("tblCustomerEvent"); 
    builder.EntitySet<tblEventComment>("tblEventComment"); 
    builder.EntitySet<tblGenre>("tblGenre"); 
    builder.EntitySet<tblPublicity>("tblPublicity"); 
    builder.EntitySet<tblUser>("tblUser"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblEventsController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblEvents
        [EnableQuery]
        public IQueryable<tblEvent> GettblEvents()
        {
            return db.tblEvent;
        }

        // GET: odata/tblEvents(5)
        [EnableQuery]
        public SingleResult<tblEvent> GettblEvent([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblEvent.Where(tblEvent => tblEvent.event_id == key));
        }

        // PUT: odata/tblEvents(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblEvent> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblEvent tblEvent = await db.tblEvent.FindAsync(key);
            if (tblEvent == null)
            {
                return NotFound();
            }

            patch.Put(tblEvent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEventExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblEvent);
        }

        // POST: odata/tblEvents
        public async Task<IHttpActionResult> Post(tblEvent tblEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEvent.Add(tblEvent);
            await db.SaveChangesAsync();

            return Created(tblEvent);
        }

        // PATCH: odata/tblEvents(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblEvent> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblEvent tblEvent = await db.tblEvent.FindAsync(key);
            if (tblEvent == null)
            {
                return NotFound();
            }

            patch.Patch(tblEvent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEventExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblEvent);
        }

        // DELETE: odata/tblEvents(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblEvent tblEvent = await db.tblEvent.FindAsync(key);
            if (tblEvent == null)
            {
                return NotFound();
            }

            db.tblEvent.Remove(tblEvent);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblEvents(5)/tblArtist
        [EnableQuery]
        public IQueryable<tblArtist> GettblArtist([FromODataUri] int key)
        {
            return db.tblEvent.Where(m => m.event_id == key).SelectMany(m => m.tblArtist);
        }

        // GET: odata/tblEvents(5)/tblCity
        [EnableQuery]
        public SingleResult<tblCity> GettblCity([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblEvent.Where(m => m.event_id == key).Select(m => m.tblCity));
        }

        // GET: odata/tblEvents(5)/tblCulturalJobTasks
        [EnableQuery]
        public SingleResult<tblCulturalJobTasks> GettblCulturalJobTasks([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblEvent.Where(m => m.event_id == key).Select(m => m.tblCulturalJobTasks));
        }

        // GET: odata/tblEvents(5)/tblCustomerEvent
        [EnableQuery]
        public IQueryable<tblCustomerEvent> GettblCustomerEvent([FromODataUri] int key)
        {
            return db.tblEvent.Where(m => m.event_id == key).SelectMany(m => m.tblCustomerEvent);
        }

        // GET: odata/tblEvents(5)/tblEventComment
        [EnableQuery]
        public IQueryable<tblEventComment> GettblEventComment([FromODataUri] int key)
        {
            return db.tblEvent.Where(m => m.event_id == key).SelectMany(m => m.tblEventComment);
        }

        // GET: odata/tblEvents(5)/tblGenre
        [EnableQuery]
        public IQueryable<tblGenre> GettblGenre([FromODataUri] int key)
        {
            return db.tblEvent.Where(m => m.event_id == key).SelectMany(m => m.tblGenre);
        }

        // GET: odata/tblEvents(5)/tblPublicity
        [EnableQuery]
        public IQueryable<tblPublicity> GettblPublicity([FromODataUri] int key)
        {
            return db.tblEvent.Where(m => m.event_id == key).SelectMany(m => m.tblPublicity);
        }

        // GET: odata/tblEvents(5)/tblUser
        [EnableQuery]
        public SingleResult<tblUser> GettblUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblEvent.Where(m => m.event_id == key).Select(m => m.tblUser));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEventExists(int key)
        {
            return db.tblEvent.Count(e => e.event_id == key) > 0;
        }
    }
}
