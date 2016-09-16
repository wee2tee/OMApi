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
    public class PopritController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        //public IEnumerable<PopritVM> Get(string api_key)
        //{
        //    if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
        //        return null;

        //    return db.Poprit.ToViewModel();
        //}

        //public IHttpActionResult Get(string api_key, int? id)
        //{
        //    if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || id == null)
        //        return NotFound();

        //    PopritVM poprit = db.Poprit.Where(p => p.Id == id).FirstOrDefault().ToViewModel();

        //    if (poprit == null)
        //        return NotFound();

        //    return Ok(poprit);
        //}

        //public IHttpActionResult Put(string api_key, int? id)
        //{
        //    Poprit poprit = db.Poprit.Where(p => p.Id == id).FirstOrDefault();
        //    poprit.StkDes = poprit.StkDes + "...";

        //    db.SaveChanges();
        //    return Ok(poprit);
        //}

        [AcceptVerbs("GET")]
        [ActionName("GetOrder")]
        public IHttpActionResult GetOrderAll(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            List<PopritVM> poprit = db.Poprit.ToViewModel();

            //var response = Request.CreateResponse<List<PopritVM>>(HttpStatusCode.ok)
            return Ok<List<PopritVM>>(poprit);
        }

    }
}
