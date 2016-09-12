using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMApi.Models;

namespace OMApi.Controllers
{
    public class UsersController : ApiController
    {
        OMApiEntities db = new OMApiEntities();

        public HttpResponseMessage PostUsers([FromBody] InternalUsers users )
        {
            db.InternalUsers.Add(users);
            db.SaveChanges();
            var response = Request.CreateResponse<InternalUsers>(HttpStatusCode.Created, users);

            string uri = Url.Link("DefaultApi", new { id = users.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
