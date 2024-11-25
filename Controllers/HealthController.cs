using HealthApplication.Model;
using HealthApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace HealthApplication.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly HealthServices _healthService;
        public HealthController(HealthServices healthService)
        {
            _healthService = healthService;
        }
        // GET
        
        [HttpGet]
        public async Task<ActionResult<List<HealthModel>>> Get([FromQuery] string id = null, [FromQuery] string billId = "", [FromQuery] string name = "")
        {

            if (!string.IsNullOrEmpty(id))
            {
                var healthbyid = await _healthService.GetAllHealthByIdAsync(id);

                if (healthbyid == null)
                {
                    return NotFound("record not found");
                }
                return Ok(healthbyid);
            }
            else
            {
                var users = await _healthService.GetAllHealthAsync( name , billId);
                return Ok(users);
            }


        }


        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> Upsert([FromBody] HealthModel healthModel, string id = null)
        {

        
            if (!string.IsNullOrEmpty(id))
            {
                healthModel.Id = id;

                var wasUpdated = await _healthService.UpdateHealthAsync(id, healthModel);
                if (!wasUpdated)
                {
                    return NotFound("Record not found");
                }
                return Ok("Record updated successfully");
            }
            else
            {

                
                healthModel.BillId = GenerateBillId();

               
                //healthModel.BillNo = GenerateBillNo();
                await _healthService.CreateHealthAsync(healthModel);
                return Ok("record created");

            }
        }
        private string GenerateBillId()
        {
            var random = new Random();
            return random.Next(1000, 10000).ToString();
        }
        //private string GenerateBillNo()
        //{
        //    return $"Cap-{GetNextAutoNo:D4}";
        //}

    }
}


