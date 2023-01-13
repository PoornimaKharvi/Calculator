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

        ADESEntities3 aad = new ADESEntities3();
        [HttpGet]
        public string GetNumbers(string firstnumber, string secondnumber,string operation)
          {
            double c = 0;
            try
            {               
                if (operation == "button1")
                {
                    c = Convert.ToDouble(firstnumber) + Convert.ToDouble(secondnumber);
                }
                else if (operation == "button2")
                {
                    c = Convert.ToDouble(firstnumber) - Convert.ToDouble(secondnumber);
                }
                else if (operation == "button3")
                {
                    c = Convert.ToDouble(firstnumber) / Convert.ToDouble(secondnumber);
                }
                else if (operation == "button4")
                {
                    c = Convert.ToDouble(firstnumber) * Convert.ToDouble(secondnumber);
                }               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return c.ToString();
        }
        [HttpPost]
        public IHttpActionResult insertresult(Calculator c)
        {
            try
            {                
                aad.Calculators.Add(c);
                aad.SaveChanges();                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok("Record saved successfully");
        }
       public IHttpActionResult getResult()
        {                                                     
            return Ok(aad.Calculators.ToList());
        }
    }
}
