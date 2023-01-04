using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleCalci.Controllers
{
    public class CalciController : ApiController
    {
        [HttpGet]
        public string GetNumbers(string firstnumber, string secondnumber,string operation)
          {
            int c=0; 
            if (operation == "button1")
            {
                 c = Convert.ToInt16(firstnumber) + Convert.ToInt16(secondnumber);
            }
            else if (operation == "button2")
            {
                c = Convert.ToInt16(firstnumber) - Convert.ToInt16(secondnumber);
            }
            else if (operation == "button3")
            {
                c = Convert.ToInt16(firstnumber) * Convert.ToInt16(secondnumber);
            }
            else if (operation == "button4")
            {
                c = Convert.ToInt16(firstnumber) / Convert.ToInt16(secondnumber);
            }
            return c.ToString();
        }
        [HttpPost]
        public IHttpActionResult insertresult(Calculator c)
        {
            ADESEntities2 aad = new ADESEntities2();
            aad.Calculators.Add(c);
            aad.SaveChanges();
            return Ok("Record saved successfully");
        }
       public IHttpActionResult getResult()
        {
            ADESEntities2 ad = new ADESEntities2();
            var result = ad.Calculators.ToList();
            return Ok(result);
        }
    }
}
