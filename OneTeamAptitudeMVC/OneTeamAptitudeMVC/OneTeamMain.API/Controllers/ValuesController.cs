using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Oneteammain.ViewModel;



namespace OneTeamMain.API.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public HttpResponseMessage GetDetails(int id)
        {
            List<Category> std = new List<Category>();
            // return Request.CreateResponse<List<Student>>(HttpStatusCode.OK, std);
            return Request.CreateResponse(HttpStatusCode.OK, "Save");
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
