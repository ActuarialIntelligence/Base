using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Financial_Instrument_Objects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<decimal>
            GetZSpreadSpecificAnnuity(ListTermCashflowSet cashFlowSet, int days,decimal nominal)
        {
            ZSpreadSpecificAnnuity annuity = new ZSpreadSpecificAnnuity(cashFlowSet, days);
            var result = Interpolation.Interpolate(annuity.GetPV, 0.01m, 0.09m, nominal);
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
