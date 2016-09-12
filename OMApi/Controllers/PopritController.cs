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

        public IEnumerable<PopritVM> Get(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            return db.Poprit.ToViewModel();
        }

        //public IEnumerable<PopritVM> Get(string api_key, bool is_list, string dealer)
        //{
        //    if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || dealer == null)
        //        return null;

        //    return db.Poprit.Where(p => p.Popr.CreBy == dealer).ToViewModel();
        //}

        public IHttpActionResult Get(string api_key, int? id)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || id == null)
                return NotFound();

            PopritVM poprit = db.Poprit.Where(p => p.Id == id).FirstOrDefault().ToViewModel();

            if (poprit == null)
                return NotFound();

            return Ok(poprit);
        }

        public IHttpActionResult Put(string api_key, int? id)
        {
            Poprit poprit = db.Poprit.Where(p => p.Id == id).FirstOrDefault();
            poprit.StkDes = poprit.StkDes + "...";

            db.SaveChanges();
            return Ok(poprit);
        }


    }
}
