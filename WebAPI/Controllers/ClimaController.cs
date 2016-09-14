using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

namespace WebAPI.Controllers
{
    public class ClimaController : ApiController
    {
        fdasys_tempEntities db = new fdasys_tempEntities();


        public class ClimaModel
        {

            public int dia { get; set; }
            public string clima { get; set; }
        }        
        
        
        // GET api/<controller>
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<string> Get()
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // GET api/<controller>/5
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ClimaModel Get(int id)
        {

            var query = db.ufn_GetWeatherDayWS(id).FirstOrDefault();

            if (query == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ClimaModel cm = new ClimaModel();
            cm.dia = id;
            cm.clima = query.ToString();

            return cm; 
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
    }
}