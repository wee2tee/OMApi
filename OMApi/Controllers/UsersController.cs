using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OMApi.Models;
using OMApi.MiscClass;
using Crypto;
//using System.Web.Mvc;

namespace OMApi.Controllers
{
    public class UsersController : ApiController
    {
        private OMApiEntities db = new OMApiEntities();

        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        [AcceptVerbs("GET")]
        [ActionName("Get")]
        public IEnumerable<InternalUsersVM> GetAll(string api_key)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            return db.InternalUsers.ToViewModel();
        }

        [AcceptVerbs("GET")]
        [ActionName("Get")]
        public IHttpActionResult GetAt(string api_key, int id)
        {
            if (api_key == null || api_key != ApiResource.GetValueOf("API_KEY"))
                return null;

            InternalUsersVM user =  db.InternalUsers.Where(u => u.Id == id).FirstOrDefault().ToViewModel();

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [AcceptVerbs("POST")]
        [ActionName("Add")]
        public HttpResponseMessage AddUser([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            api.internalUsers.PasswordHash = api.internalUsers.UserName.MD5Hash(); //api.internalUsers.UserName.MD5WithSaltHash(api.API_KEY);
            db.InternalUsers.Add(api.internalUsers);
            db.SaveChanges();
            var response = Request.CreateResponse<InternalUsersVM>(HttpStatusCode.Created, api.internalUsers.ToViewModel());

            //string uri = Url.Link("DefaultApi", new { id = api.internalUsers.Id });
            //response.Headers.Location = new Uri(uri);
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("Edit")]
        public HttpResponseMessage EditUser([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            InternalUsers user = db.InternalUsers.Where(u => u.Id == api.internalUsers.Id).FirstOrDefault();

            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            user.FullName = api.internalUsers.FullName;
            user.Email = api.internalUsers.Email;
            user.Department = api.internalUsers.Department;
            user.Status = api.internalUsers.Status;
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            var response = Request.CreateResponse<InternalUsersVM>(HttpStatusCode.Created, user.ToViewModel());
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("ChangePassword")]
        public HttpResponseMessage ChangePwd([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse<string>(HttpStatusCode.Forbidden, "ท่านไม่ได้รับอนุญาตให้ใช้งานระบบ");

            InternalUsers user = db.InternalUsers.Where(u => u.Id == api.changePasswordModel.Id).FirstOrDefault();

            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            if (api.changePasswordModel.PasswordHash.MD5Hash() != user.PasswordHash)
                return Request.CreateResponse<string>(HttpStatusCode.Forbidden, "รหัสผ่านเดิมไม่ถูกต้อง");

            user.PasswordHash = api.changePasswordModel.NewPassword.MD5Hash();
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            var response = Request.CreateResponse<InternalUsersVM>(HttpStatusCode.Created, user.ToViewModel());
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("ResetPassword")]
        public HttpResponseMessage ResetPwd([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            InternalUsers user = db.InternalUsers.Where(u => u.Id == api.internalUsers.Id).FirstOrDefault();

            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            user.PasswordHash = user.UserName.MD5Hash();
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            var response = Request.CreateResponse<InternalUsersVM>(HttpStatusCode.Created, user.ToViewModel());
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("Delete")]
        public HttpResponseMessage DeleteUser([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            InternalUsers user = db.InternalUsers.Where(u => u.Id == api.internalUsers.Id).FirstOrDefault();

            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.InternalUsers.Remove(user);
            db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [AcceptVerbs("POST")]
        [ActionName("SignIn")]
        public HttpResponseMessage SignIn([FromBody] ApiAccessibilities api)
        {
            if (api == null || api.API_KEY != ApiResource.GetValueOf("API_KEY"))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            string passwordHash = api.internalUsers.PasswordHash.MD5Hash();

            InternalUsersVM user = db.InternalUsers.Where(u => u.UserName == api.internalUsers.UserName && u.PasswordHash == passwordHash).FirstOrDefault().ToViewModel();

            if (user != null)
            {
                HttpResponseMessage response = Request.CreateResponse<InternalUsersVM>(HttpStatusCode.OK, user);
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden, "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง");
                return response;
            }
        }
    }
}
