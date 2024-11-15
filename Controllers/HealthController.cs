using HealthApplication.Model;
using HealthApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace HealthApplication.Controllers
{
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
        public async Task<ActionResult<List<HealthModel>>> Get([FromQuery] string id = null, [FromQuery] string billNo = "", [FromQuery] string name = "")
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
                var users = await _healthService.GetAllHealthAsync( name ,billNo);
                return Ok(users);
            }


        }
        //// POST
        //[HttpPost]
        //public async Task<ActionResult> Create([FromBody] HealthModel health)
        //{
        //    // Insert into database or further processing
        //    await _healthService.CreateHealthAsync(health);
        //    return Ok();
        //}


        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] HealthModel healthModel, string id = null)
        {

            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(x => x.Errors)
            //    .Select(errors => errors.ErrorMessage)
            //        .ToList();
            //    return BadRequest(new { Message = "validation error", Errors = errors });
            //}
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
                await _healthService.CreateHealthAsync(healthModel);
                return Ok("record created");

            }
        }

    }
}


