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
        public enum POPR_STATUS : int
        {
            PO_PREPARE = 0,
            PO_NEW = 1,
            PO_CONVERTED = 2,
            PO_INVOICED = 3,
            PO_COMPLETED = 4,
            PO_DELIVERED = 5,
            PO_CANCELED = 6
        }

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

        [AcceptVerbs("POST")]
        [ActionName("UpdateSoNum")]
        public HttpResponseMessage UpDateSoNum2Po([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.poprit == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            Poprit poprit = this.db.Poprit.Where(p => p.Id == api.poprit.Id).FirstOrDefault();

            if (poprit == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            if (poprit.Popr.Status == POPR_STATUS.PO_CONVERTED.ToString()) // this item is already done by another user
                return Request.CreateResponse<PopritVM>(HttpStatusCode.OK, poprit.ToViewModel()); // just only return OK

            poprit.SoNum = api.poprit.SoNum;
            poprit.SoDat = api.poprit.SoDat;
            poprit.SoBy = api.poprit.SoBy;
            poprit.SoCreDate = DateTime.Now;
            poprit.SoRemark = api.poprit.SoRemark;
            poprit.Popr.Status = POPR_STATUS.PO_CONVERTED.ToString();

            db.Entry(poprit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            var response = Request.CreateResponse<PopritVM>(HttpStatusCode.OK, poprit.ToViewModel());
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("UpdateIvNum")]
        public HttpResponseMessage UpDateIvNum2Po([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.poprit == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var poprit = this.db.Poprit.Where(p => p.SoNum != null && p.SoNum.Substring(0, 12).Trim() == api.poprit.SoNum);

            if (poprit.First().Popr.Status == POPR_STATUS.PO_INVOICED.ToString()) // this item is already done by another user 
                return Request.CreateResponse(HttpStatusCode.OK); // just only return OK

            foreach (var item in poprit)
            {
                item.IvNum = api.poprit.IvNum;
                item.IvDat = api.poprit.IvDat;
                item.IvBy = api.poprit.IvBy;
                item.IvCreDate = DateTime.Now;
                item.Popr.Status = POPR_STATUS.PO_INVOICED.ToString();
            }
            
            this.db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("UpdateEmsTracking")]
        public HttpResponseMessage UpdateEms([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.poprit == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var poprit = this.db.Poprit.Where(p => p.IvNum != null && p.IvNum.Substring(0, 12).Trim() == api.poprit.IvNum);

            if (poprit.First().EmsTracking.Trim().Length > 0) // this item is already done by another user
                return Request.CreateResponse(HttpStatusCode.OK); // just only return OK

            foreach (var item in poprit)
            {
                item.EmsTracking = api.poprit.EmsTracking;
            }

            this.db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
