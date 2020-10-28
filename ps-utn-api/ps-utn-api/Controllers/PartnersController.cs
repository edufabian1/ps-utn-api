using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementEsports.Business;
using ManagementEsports.Data.Repositories;
using ManagementEsports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ps_utn_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartnersController : ControllerBase
    {
        public PartnerBus partnerBus = new PartnerBus(new PartnerRepository());

        public PartnersController()
        {
        }

        [HttpGet]
        [Route("{partnerId}")]
        public async Task<ActionResult<Partner>> GetPartnerById(int partnerId)
        {
            var result = await partnerBus.GetById(partnerId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
        {
            var result = await partnerBus.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Partner>>> InsertPartners([FromBody]Partner partner)
        {
            await partnerBus.Insert(partner);
            return Ok("Finalizado correctamente");
        }

        [HttpPut]
        [Route("{partnerId}")]
        public async Task<ActionResult<IEnumerable<Partner>>> UpdatePartners([FromBody]Partner partner)
        {
            await partnerBus.Update(partner);
            return Ok("Finalizado correctamente");
        }

        [HttpDelete]
        [Route("{partnerId}")]
        public async Task<ActionResult<IEnumerable<Partner>>> DeletePartners(int partnerId)
        {
            await partnerBus.Delete(partnerId);
            return Ok("Finalizado correctamente");
        }
    }
}
