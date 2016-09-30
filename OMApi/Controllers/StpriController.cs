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

            List<StpriVM> stpri = this.db.Stpri.OrderBy(s => s.PriceCode).ToViewModel();

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

        [AcceptVerbs("POST")]
        [ActionName("AddStpri")]
        public HttpResponseMessage AddNewStpri([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.stpri == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (this.db.Stpri.Where(s => s.PriceCode.Trim() == api.stpri.PriceCode.Trim()).Count() > 0)
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, "รหัส \"" + api.stpri.PriceCode.Trim() + "\" นี้มีอยู่แล้ว");

            Stpri stpri = new Stpri
            {
                PriceCode = api.stpri.PriceCode,
                Description = api.stpri.Description,
                TabPr = api.stpri.TabPr,
                Disc1 = api.stpri.Disc1,
                DiscPerc1 = api.stpri.DiscPerc1,
                Disc2 = api.stpri.Disc2,
                DiscPerc2 = api.stpri.DiscPerc2,
                CreBy = api.stpri.CreBy,
                CreDate = DateTime.Now
            };

            this.db.Stpri.Add(stpri);
            this.db.SaveChanges();

            return Request.CreateResponse<StpriVM>(HttpStatusCode.Created, stpri.ToViewModel());
        }

        [AcceptVerbs("POST")]
        [ActionName("UpdateStpri")]
        public HttpResponseMessage UpdateStpri([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.stpri == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Stpri stpri = this.db.Stpri.Find(api.stpri.Id);

            if (stpri == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            stpri.Description = api.stpri.Description;
            stpri.TabPr = api.stpri.TabPr;
            stpri.Disc1 = api.stpri.Disc1;
            stpri.DiscPerc1 = api.stpri.DiscPerc1;
            stpri.Disc2 = api.stpri.Disc2;
            stpri.DiscPerc2 = api.stpri.DiscPerc2;
            stpri.ChgBy = api.stpri.ChgBy;
            stpri.ChgDate = DateTime.Now;

            this.db.SaveChanges();
            return Request.CreateResponse<StpriVM>(HttpStatusCode.OK, stpri.ToViewModel());
        }

        [AcceptVerbs("POST")]
        [ActionName("DeleteStpri")]
        public HttpResponseMessage DeleteStpri([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.stpri == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Stpri stpri = this.db.Stpri.Find(api.stpri.Id);

            if (stpri == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            this.db.Stpri.Remove(stpri);
            this.db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
