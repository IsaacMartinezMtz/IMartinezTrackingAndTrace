using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/UnidadEntrega")]
    public class UnidadEntregaController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.UnidadEntrega unidadEntrega = BL.UnidadEntrega.GetAll();
            if (unidadEntrega.Correct)
            {
                return Content(HttpStatusCode.OK, unidadEntrega);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, unidadEntrega);

            }

        }
        

    }
}
