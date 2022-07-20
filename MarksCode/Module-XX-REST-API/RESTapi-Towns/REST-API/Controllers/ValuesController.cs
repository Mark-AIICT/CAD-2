using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using N=Newtonsoft.Json;

namespace REST_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Models.Town> Get()
        {
            return HttpContext.Current.Application[0] as List<Models.Town>;
        }

        // GET api/values/1111
        public Models.Town Get(int postCode)
        {
            List<Models.Town> towns = HttpContext.Current.Application[0] as List<Models.Town>;
            return towns.Where(t=>t.PostCode== postCode).FirstOrDefault();
        }

        // POST api/values
        public Models.Town Post(int postCode)
        {
            List<Models.Town> towns = HttpContext.Current.Application[0] as List<Models.Town>;
            return towns.Where(t => t.PostCode == postCode).FirstOrDefault();
        }

        // PUT api/values                           
        public void Put(Models.Town t)
        {
            List<Models.Town> towns = HttpContext.Current.Application[0] as List<Models.Town>;
            towns.Add(new Models.Town { PostCode = t.PostCode, TownName = t.TownName });

        }

        // Patch api/values     
        [HttpPost]
        public void Patch(Models.Town t)
        {
            List<Models.Town> towns = HttpContext.Current.Application[0] as List<Models.Town>;
            if (towns.Where(x => x.PostCode == t.PostCode).Count() == 1)
            {
                Models.Town townToUpdate = towns.Where(x => x.PostCode == t.PostCode).First();
                townToUpdate.TownName = t.TownName;
            }
        }

        // DELETE api/values/1111
        public void Delete(int postCode)
        {
            List<Models.Town> towns = HttpContext.Current.Application[0] as List<Models.Town>;
            if (towns.Where(t => t.PostCode == postCode).Count() == 1)
                towns.Remove(towns.Where(t => t.PostCode == postCode).First());
        }
    }


}
