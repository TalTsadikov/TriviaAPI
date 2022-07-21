using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TriviaAPI.Controllers
{
    public class PlayerAnswerController : ApiController
    {
        // GET: api/PlayerAnswer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PlayerAnswer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PlayerAnswer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlayerAnswer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PlayerAnswer/5
        public void Delete(int id)
        {
        }
    }
}
