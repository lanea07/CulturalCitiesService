using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace CulturalCitiesService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            /*config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<tblArtist>("tblArtists");
            builder.EntitySet<tblCity>("tblCity");
            builder.EntitySet<tblCountry>("tblCountry");
            builder.EntitySet<tblCulturalJobTasks>("tblCulturalJobTasks");
            builder.EntitySet<tblCustomer>("tblCustomers");
            builder.EntitySet<tblCustomerEvent>("tblCustomerEvent");
            builder.EntitySet<tblCustomerPreferences>("tblCustomerPreferences");
            builder.EntitySet<tblEvent>("tblEvent");
            builder.EntitySet<tblEventComment>("tblEventComment");
            builder.EntitySet<tblGenre>("tblGenre");
            builder.EntitySet<tblPreferenceValue>("tblPreferenceValue");
            builder.EntitySet<tblPublicity>("tblPublicity");
            builder.EntitySet<tblUser>("tblUser");
            builder.EntitySet<tblUserRole>("tblUserRole");
            builder.Entity<tblCustomer>().Collection.Action("Login");
            config.Routes.MapODataRoute("webservice", "webservice", builder.GetEdmModel());

        }
    }
}
