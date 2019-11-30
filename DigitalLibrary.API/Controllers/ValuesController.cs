using System.Collections.Generic;
using System.Linq;
using DigitalLibrary.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary
{
	[Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
	    private readonly ApplicationDbContext _applicationDbContext;

	    public ValuesController(ApplicationDbContext applicationDbContext)
	    {
		    _applicationDbContext = applicationDbContext;
	    }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
	        var test = _applicationDbContext.Users.Select(x => x.UserName).ToList();
            return test;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
