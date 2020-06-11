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
    builder.EntitySet<tblPreferenceValue>("tblPreferenceValues");
    builder.EntitySet<tblCustomerPreferences>("tblCustomerPreferences"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblPreferenceValuesController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblPreferenceValues
        [EnableQuery]
        public IQueryable<tblPreferenceValue> GettblPreferenceValues()
        {
            return db.tblPreferenceValue;
        }

        // GET: odata/tblPreferenceValues(5)
        [EnableQuery]
        public SingleResult<tblPreferenceValue> GettblPreferenceValue([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblPreferenceValue.Where(tblPreferenceValue => tblPreferenceValue.preference_id == key));
        }

        // PUT: odata/tblPreferenceValues(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblPreferenceValue> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblPreferenceValue tblPreferenceValue = await db.tblPreferenceValue.FindAsync(key);
            if (tblPreferenceValue == null)
            {
                return NotFound();
            }

            patch.Put(tblPreferenceValue);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPreferenceValueExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblPreferenceValue);
        }

        // POST: odata/tblPreferenceValues
        public async Task<IHttpActionResult> Post(tblPreferenceValue tblPreferenceValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPreferenceValue.Add(tblPreferenceValue);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tblPreferenceValueExists(tblPreferenceValue.preference_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(tblPreferenceValue);
        }

        // PATCH: odata/tblPreferenceValues(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblPreferenceValue> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblPreferenceValue tblPreferenceValue = await db.tblPreferenceValue.FindAsync(key);
            if (tblPreferenceValue == null)
            {
                return NotFound();
            }

            patch.Patch(tblPreferenceValue);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPreferenceValueExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblPreferenceValue);
        }

        // DELETE: odata/tblPreferenceValues(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblPreferenceValue tblPreferenceValue = await db.tblPreferenceValue.FindAsync(key);
            if (tblPreferenceValue == null)
            {
                return NotFound();
            }

            db.tblPreferenceValue.Remove(tblPreferenceValue);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblPreferenceValues(5)/tblCustomerPreferences
        [EnableQuery]
        public IQueryable<tblCustomerPreferences> GettblCustomerPreferences([FromODataUri] int key)
        {
            return db.tblPreferenceValue.Where(m => m.preference_id == key).SelectMany(m => m.tblCustomerPreferences);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPreferenceValueExists(int key)
        {
            return db.tblPreferenceValue.Count(e => e.preference_id == key) > 0;
        }
    }
}
