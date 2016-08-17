using EF.Core.Domain;
using EF.Core.Extensions;
using EF.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace Test.WebClient.Controllers
{
    public class APIControllerBase<T>:ApiController where T:IdentityEntity,new()
    {
        public IdentityServiceBase<T> svc = new IdentityServiceBase<T>();

        [AcceptVerbs("POST","GET","PUT")]
        [EnableQuery]
        public IQueryable<T> Get()
        {
            return svc.Set;
        }

        [AcceptVerbs("POST", "GET", "PUT")]
        [PagedQueryInterface]
        public PagedResult<T> Query(QueryObject q)
        {

            return svc.Query(q);
        }

        [AcceptVerbs("POST", "GET", "PUT")]
       // [ResponseType(typeof(T))]
        public IHttpActionResult GetApplicationUser(long id)
        {
            T t = svc.Get(id);
            if (t == null)
            {
                return NotFound();
            }

            return Ok(t);
        }
        [AcceptVerbs("POST", "GET", "PUT")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(long id, T t)
        {
            try
            {

                svc.Save(t, id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AcceptVerbs("POST", "GET", "PUT")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(List<T> ts)
        {
            try
            {

                svc.Save(ts);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST", "GET", "PUT")]
        //[ResponseType(typeof(T))]
        public IHttpActionResult Post(T t)
        {
            try
            {
                svc.Create(t);
                return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST", "GET", "PUT","DELETE")]
        //[ResponseType(typeof(T))]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                var item =svc.Get(id);
                svc.Delete(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}