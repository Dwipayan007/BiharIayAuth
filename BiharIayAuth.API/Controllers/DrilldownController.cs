using BiharIayAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiharIayAuth.API.Controllers
{
    public class DrilldownController : ApiController
    {
        // GET: api/Drilldown
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Drilldown/5
        public List<DrilldownData> Get(string id)
        {
            return dbUtility.GetDrilldownData(id);
        }

        // POST: api/Drilldown
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Drilldown/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Drilldown/5
        public void Delete(int id)
        {
        }
    }
}
