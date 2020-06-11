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
    builder.EntitySet<tblCustomerPreferences>("tblCustomerPreferences");
    builder.EntitySet<tblCustomer>("tblCustomer"); 
    builder.EntitySet<tblPreferenceValue>("tblPreferenceValue"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblCustomerPreferencesController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblCustomerPreferences
        [EnableQuery]
        public IQueryable<tblCustomerPreferences> GettblCustomerPreferences()
        {
            return db.tblCustomerPreferences;
        }

        // GET: odata/tblCustomerPreferences(5)
        [EnableQuery]
        public SingleResult<tblCustomerPreferences> GettblCustomerPreferences([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCustomerPreferences.Where(tblCustomerPreferences => tblCustomerPreferences.customer_id == key));
        }

        // PUT: odata/tblCustomerPreferences(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblCustomerPreferences> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCustomerPreferences tblCustomerPreferences = await db.tblCustomerPreferences.FindAsync(key);
            if (tblCustomerPreferences == null)
            {
                return NotFound();
            }

            patch.Put(tblCustomerPreferences);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCustomerPreferencesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCustomerPreferences);
        }

        // POST: odata/tblCustomerPreferences
        public async Task<IHttpActionResult> Post(tblCustomerPreferences tblCustomerPreferences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCustomerPreferences.Add(tblCustomerPreferences);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tblCustomerPreferencesExists(tblCustomerPreferences.customer_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tblCustomerPreferences);
        }

        // PATCH: odata/tblCustomerPreferences(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblCustomerPreferences> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCustomerPreferences tblCustomerPreferences = await db.tblCustomerPreferences.FindAsync(key);
            if (tblCustomerPreferences == null)
            {
                return NotFound();
            }

            patch.Patch(tblCustomerPreferences);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCustomerPreferencesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCustomerPreferences);
        }

        // DELETE: odata/tblCustomerPreferences(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblCustomerPreferences tblCustomerPreferences = await db.tblCustomerPreferences.FindAsync(key);
            if (tblCustomerPreferences == null)
            {
                return NotFound();
            }

            db.tblCustomerPreferences.Remove(tblCustomerPreferences);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblCustomerPreferences(5)/tblCustomer
        [EnableQuery]
        public SingleResult<tblCustomer> GettblCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCustomerPreferences.Where(m => m.customer_id == key).Select(m => m.tblCustomer));
        }

        // GET: odata/tblCustomerPreferences(5)/tblPreferenceValue
        [EnableQuery]
        public SingleResult<tblPreferenceValue> GettblPreferenceValue([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCustomerPreferences.Where(m => m.customer_id == key).Select(m => m.tblPreferenceValue));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCustomerPreferencesExists(int key)
        {
            return db.tblCustomerPreferences.Count(e => e.customer_id == key) > 0;
        }
    }
}
