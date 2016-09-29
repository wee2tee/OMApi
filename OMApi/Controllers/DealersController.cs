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
    public enum USER_TYPE : int
    {
        INTERNAL = 0,
        EXTERNAL = 1
    }

    public enum USER_GROUP : int
    {
        DEALER = 0,
        SUPPORT = 1,
        MARKETTING = 2,
        ACCOUNT = 3,
        OTHER = 4,
        ADMIN = 99
    }

    public enum DEALER_TYPE : int
    {
        ไม่ระบุ = 0,
        ตัวแทนจำหน่ายทั่วไป = 1,
        ตัวแทนจำหน่ายรายใหญ่ = 2,
        สำนักงานบัญชีไฮเทค = 3
    }

    public class DealersController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        [AcceptVerbs("GET")]
        [ActionName("GetDealer")]
        public IHttpActionResult GetAllDealers(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            List<DealerVM> dealers = this.db.AspNetUsers.Where(a => a.UserType == (int)USER_TYPE.EXTERNAL).ToViewModel();

            return Ok<List<DealerVM>>(dealers);
        }

        [AcceptVerbs("GET")]
        [ActionName("GetDealerAt")]
        public IHttpActionResult GetDealerAt(string api_key, string id)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY") || id == null || id.Trim().Length == 0)
                return null;

            DealerVM dealers = this.db.AspNetUsers.Where(a => a.UserType == (int)USER_TYPE.EXTERNAL && a.Id == id).FirstOrDefault().ToViewModel();

            return Ok<DealerVM>(dealers);
        }

        [AcceptVerbs("POST")]
        [ActionName("Update")]
        public HttpResponseMessage UpdateDealer([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY") || api.dealer == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            AspNetUsers user = this.db.AspNetUsers.Where(u => u.Id == api.dealer.Id).FirstOrDefault();
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            user.DealerCode = api.dealer.DealerCode;
            user.DealerType = api.dealer.DealerType;
            user.PriceCode = api.dealer.PriceCode;
            user.DlvProfile = api.dealer.DlvProfile;
            user.Status = api.dealer.Status;

            //user.SerNum = api.dealer.SerNum;
            //user.PreName = api.dealer.PreName;
            //user.FullName = api.dealer.FullName;
            //user.TaxId = api.dealer.TaxId;
            //user.Addr01 = api.dealer.Addr01;
            //user.Addr02 = api.dealer.Addr02;
            //user.Addr03 = api.dealer.Addr03;
            //user.ZipCod = api.dealer.ZipCod;
            //user.TelNum = api.dealer.TelNum;
            //user.FaxNum = api.dealer.FaxNum;

            this.db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
