using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CulturalCitiesService;
using Microsoft.AspNet.OData.Routing;
using Newtonsoft.Json;

namespace CulturalCitiesService.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CulturalCitiesService;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<tblCustomer>("tblCustomers");
    builder.EntitySet<tblCity>("tblCity"); 
    builder.EntitySet<tblCustomerEvent>("tblCustomerEvent"); 
    builder.EntitySet<tblCustomerPreferences>("tblCustomerPreferences"); 
    builder.EntitySet<tblEventComment>("tblEventComment"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class tblCustomersController : ODataController
    {
        private DataModel db = new DataModel();

        // GET: odata/tblCustomers
        //USED FOR LOGIN
        [EnableQuery]
        public IQueryable<tblCustomer> GettblCustomers()
        {
            return db.tblCustomer;
        }

        // GET: odata/tblCustomers(5)
        [EnableQuery]
        public SingleResult<tblCustomer> GettblCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCustomer.Where(tblCustomer => tblCustomer.customer_id == key));
        }

        // PUT: odata/tblCustomers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<tblCustomer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCustomer tblCustomer = await db.tblCustomer.FindAsync(key);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            patch.Put(tblCustomer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCustomer);
        }

        // POST: odata/tblCustomers
        public async Task<IHttpActionResult> Post(tblCustomer tblCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCustomer.Add(tblCustomer);
            await db.SaveChangesAsync();

            return Created(tblCustomer);
        }

        // PATCH: odata/tblCustomers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<tblCustomer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tblCustomer tblCustomer = await db.tblCustomer.FindAsync(key);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            patch.Patch(tblCustomer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tblCustomer);
        }

        // DELETE: odata/tblCustomers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            tblCustomer tblCustomer = await db.tblCustomer.FindAsync(key);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            db.tblCustomer.Remove(tblCustomer);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/tblCustomers(5)/tblCity
        [EnableQuery]
        public SingleResult<tblCity> GettblCity([FromODataUri] int key)
        {
            return SingleResult.Create(db.tblCustomer.Where(m => m.customer_id == key).Select(m => m.tblCity));
        }

        // GET: odata/tblCustomers(5)/tblCustomerEvent
        [EnableQuery]
        public IQueryable<tblCustomerEvent> GettblCustomerEvent([FromODataUri] int key)
        {
            return db.tblCustomer.Where(m => m.customer_id == key).SelectMany(m => m.tblCustomerEvent);
        }

        // GET: odata/tblCustomers(5)/tblCustomerPreferences
        [EnableQuery]
        public IQueryable<tblCustomerPreferences> GettblCustomerPreferences([FromODataUri] int key)
        {
            return db.tblCustomer.Where(m => m.customer_id == key).SelectMany(m => m.tblCustomerPreferences);
        }

        // GET: odata/tblCustomers(5)/tblEventComment
        [EnableQuery]
        public IQueryable<tblEventComment> GettblEventComment([FromODataUri] int key)
        {
            return db.tblCustomer.Where(m => m.customer_id == key).SelectMany(m => m.tblEventComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCustomerExists(int key)
        {
            return db.tblCustomer.Count(e => e.customer_id == key) > 0;
        }
    }

    public class auxCustomerLoginClass
    {
        [JsonProperty]
        public string username { get; set; }
        [JsonProperty]
        public string password { get; set; }
    }
}
