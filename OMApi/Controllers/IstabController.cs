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
                istab = this.db.Istab.ToViewModel();
            }
            else
            {
                istab = this.db.Istab.Where(i => i.TabTyp == tabtyp).ToViewModel();
            }

            return Ok<List<IstabVM>>(istab);
        }
    }
}
