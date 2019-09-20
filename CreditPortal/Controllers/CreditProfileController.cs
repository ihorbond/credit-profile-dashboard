using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditPortal.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditProfileController : ControllerBase
    {
        public CreditProfileController()
        {

        }

        [HttpGet("{id}", Name = "GetCreditProfileById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCreditProfileById(int id)
        {
            if (id <= 0)
                return BadRequest("Id is invalid");



            return null;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateCreditProfileById(int id, [FromBody] UpdateCreditProfileRequest body)
        {
            if (id <= 0)
                return BadRequest("ID is invalid");

            if (body == null || !ModelState.IsValid)
                return BadRequest(ModelState);



            return NoContent();
        }
    }
}