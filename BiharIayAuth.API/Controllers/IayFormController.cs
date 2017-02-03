using BiharIayAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiharIayAuth.API.Controllers
{
    public class IayFormController : ApiController
    {
        // GET: api/IayIns
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IayIns/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IayIns
        public int Post(_IayForm value)
        {
            return dbUtility.SaveIayInsReport(value);
        }

        // PUT: api/IayIns/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IayIns/5
        public void Delete(int id)
        {
        }
    }
}
