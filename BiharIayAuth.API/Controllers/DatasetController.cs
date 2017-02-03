using BiharIayAuth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace BiharIayAuth.API.Controllers
{

    [RoutePrefix("api/District")]
    public class DistrictController : ApiController
    {
        // GET: api/District
        //[Authorize(Users = "admin01")]
        //[Authorize(Roles = "abcd")]
        [Authorize(Roles = "admin")]
        [Route("")]
        public List<_District> Get()
        {
            return dbUtility.GetDistricts();
        }

        // GET: api/District/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/District
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/District/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/District/5
        public void Delete(int id)
        {
        }
    }

    public class BlockController : ApiController
    {
        // GET: api/Block
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Block/5
        public List<_Block> Get(int id)
        {
            return dbUtility.GetBlocks(id);
        }

        // POST: api/Block
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Block/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Block/5
        public void Delete(int id)
        {
        }
    }

    public class PanchayatController : ApiController
    {
        // GET: api/Panchayat
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Panchayat/5
        public List<_Panchayat> Get(int id)
        {
            return dbUtility.GetPanchayats(id);
        }

        // POST: api/Panchayat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Panchayat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Panchayat/5
        public void Delete(int id)
        {
        }
    }

    public class BenefController : ApiController
    {
        // GET: api/Benefs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Benefs/5
        public List<_Benefs> Get(int id)
        {
            return dbUtility.GetBenefs(id);
        }

        // POST: api/Benefs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Benefs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Benefs/5
        public void Delete(int id)
        {
        }
    }
}
