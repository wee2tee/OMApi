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
    }
}
