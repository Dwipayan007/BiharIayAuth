using BiharIayAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiharIayAuth.API.Controllers
{
    public class BlkLevelReportController : ApiController
    {
        // GET: api/BlkLevelReport
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BlkLevelReport/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BlkLevelReport
        public String Post(_IayForm value)
        {
            return ReportPdfGen.BlockLevelPdfGen(value);
        }

        // PUT: api/BlkLevelReport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BlkLevelReport/5
        public void Delete(int id)
        {
        }
    }

    public class PanchLevelReportController : ApiController
    {
        // GET: api/PanchLevelReport
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PanchLevelReport/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PanchLevelReport
        public String Post(_IayForm value)
        {
            return ReportPdfGen.PanchayatLevelPdfGen(value);
        }


        // PUT: api/PanchLevelReport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PanchLevelReport/5
        public void Delete(int id)
        {
        }
    }
}
