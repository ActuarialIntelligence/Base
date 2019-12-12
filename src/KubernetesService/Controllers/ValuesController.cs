using System;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesService.Controllers
{
    //http://localhost:5000/api/Domain/ZSpreadSpecificAnnuityPresentValue
    [Route("api/Domain")]
    [ApiController]
    public class DomainController : ControllerBase
    {

        // GET api/values
        [HttpGet("ZSpreadSpecificAnnuityPresentValue")]
        public ActionResult<decimal>
            GetZSpreadSpecificAnnuity(ListTermCashflowSet cashFlowSet, int days,decimal nominal)
        {
            Annuity annuity = new Annuity(cashFlowSet, days);
            var result = Interpolation.Interpolate(annuity.GetPV, 0.01m, 0.09m, nominal);
            return result;
        }
        [HttpGet("InterpolateFunction")]
        public ActionResult<decimal> InterpolateFunction(Func<decimal, decimal> functional,
            decimal testValue1, decimal testValue2, decimal interpolationValue)
        {
            var f = interpolationValue;
            var result = Interpolation.Interpolate(functional, testValue1, testValue2, f);
            return result;
        }
        [HttpPost("Test")]
        public ActionResult<ParseObject> Test(ParseObject parseObject)
        {
            var str = "";
            foreach(var a in parseObject.array)
            {
                str += a;
            }
            var result = (parseObject.testValue1 + parseObject.testValue2).ToString() + str;
            return new ParseObject() { array=new String[2]{"async","b" }, testValue1=1, testValue2=2 };
        }

       

        #region NeededLater
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
    public class ParseObject
    {
        public String[] array { get; set; }
        public decimal testValue1 { get; set; }
        public decimal testValue2 { get; set; }

    }

}
