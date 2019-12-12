using System;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesService.Controllers
{
    [Route("api/Domain")]
    [ApiController]
    public class DomainController : ControllerBase
    {

        // GET api/values
        [HttpGet("ZSpreadSpecificAnnuityPresentValue")]
        public ActionResult<decimal>
            GetZSpreadSpecificAnnuity(ListTermCashflowSet cashFlowSet, int days,decimal nominal)
        {
            ZSpreadSpecificAnnuity annuity = new ZSpreadSpecificAnnuity(cashFlowSet, days);
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
}
