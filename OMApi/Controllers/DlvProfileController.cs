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
    public class DlvProfileController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        [AcceptVerbs("GET")]
        [ActionName("GetDlvProfile")]
        public IHttpActionResult GetAllDlvProfile(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            var dlv_profile = this.db.Istab.Where(i => i.TabTyp.Trim() == IstabVM.TABTYP_DLVPROFILE).ToDlvProfileViewModel();

            return Ok<List<DlvProfileVM>>(dlv_profile);
        }
    }
}
