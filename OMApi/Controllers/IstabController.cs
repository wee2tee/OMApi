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
    public class IstabController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        [AcceptVerbs("GET")]
        [ActionName("GetIstab")]
        public IHttpActionResult GetAllIstab(string api_key, string tabtyp = "*")
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            List<IstabVM> istab;
            if(tabtyp == "*")
            {
                istab = this.db.Istab.OrderBy(i => i.TypCod).ToViewModel();
            }
            else
            {
                istab = this.db.Istab.Where(i => i.TabTyp == tabtyp).OrderBy(i => i.TypCod).ToViewModel();
            }

            return Ok<List<IstabVM>>(istab);
        }

        [AcceptVerbs("GET")]
        [ActionName("GetIstabAt")]
        public HttpResponseMessage GetIstab(string api_key, int? id)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Istab istab = this.db.Istab.Find(id);

            if (istab == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse<IstabVM>(istab.ToViewModel());
        }

        [AcceptVerbs("POST")]
        [ActionName("AddIstab")]
        public HttpResponseMessage AddNewIstab([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.istab == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (this.db.Istab.Where(i => i.TabTyp.Trim() == api.istab.TabTyp.Trim() && i.TypCod.Trim() == api.istab.TypCod.Trim()).Count() > 0)
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, "รหัส \"" + api.istab.TypCod.Trim() + "\" นี้มีอยู่แล้ว");

            Istab istab = new Istab()
            {
                TabTyp = api.istab.TabTyp,
                TypCod = api.istab.TypCod,
                AbbreviateEn = api.istab.AbbreviateEn,
                AbbreviateTh = api.istab.AbbreviateTh,
                TypDesEn = api.istab.TypDesEn,
                TypDesTh = api.istab.TypDesTh,
                Rate = api.istab.Rate,
                CreBy = api.istab.CreBy,
                CreDate = DateTime.Now
            };

            this.db.Istab.Add(istab);
            this.db.SaveChanges();

            return Request.CreateResponse<IstabVM>(HttpStatusCode.OK, istab.ToViewModel());
        }

        [AcceptVerbs("POST")]
        [ActionName("UpdateIstab")]
        public HttpResponseMessage UpdateIstab([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.istab == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Istab istab = this.db.Istab.Find(api.istab.Id);

            if (istab == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            istab.AbbreviateEn = api.istab.AbbreviateEn;
            istab.AbbreviateTh = api.istab.AbbreviateTh;
            istab.TypDesEn = api.istab.TypDesEn;
            istab.TypDesTh = api.istab.TypDesTh;
            istab.Rate = api.istab.Rate;
            istab.ChgBy = api.istab.ChgBy;
            istab.ChgDate = DateTime.Now;

            this.db.SaveChanges();
            return Request.CreateResponse<IstabVM>(HttpStatusCode.OK, istab.ToViewModel());
        }

        [AcceptVerbs("POST")]
        [ActionName("DeleteIstab")]
        public HttpResponseMessage DeleteIstab([FromBody] ApiAccessibilities api)
        {
            if (api.API_KEY == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.istab == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Istab istab = this.db.Istab.Find(api.istab.Id);

            if (istab == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            this.db.Istab.Remove(istab);
            this.db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
