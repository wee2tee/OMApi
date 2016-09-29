using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMApi.Models;
using OMApi.MiscClass;

namespace OMApi.Controllers
{
    public class StpriController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        [AcceptVerbs("GET")]
        [ActionName("GetStpri")]
        public IHttpActionResult GetAllStpri(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            List<StpriVM> stpri = this.db.Stpri.ToViewModel();

            return Ok<List<StpriVM>>(stpri);
        }

        [AcceptVerbs("GET")]
        [ActionName("GetStpriAt")]
        public HttpResponseMessage GetStpriAt(string api_key, int? id)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || id == null)
                return null;

            StpriVM stpri = this.db.Stpri.Where(s => s.Id == id).FirstOrDefault().ToViewModel();

            if (stpri == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse<StpriVM>(HttpStatusCode.OK, stpri);
        }
    }
}
