using System;
using System.Linq;
using AutoMapper;
using CreditPortal.ApiModels;
using CreditPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditPortal.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditProfilesController : ControllerBase
    {
        private readonly CreditPortalContext _context;
        private readonly IMapper _mapper;

        public CreditProfilesController(CreditPortalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get customer's credit profile by id
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <param name="profileId">Credit Profile ID</param>
        /// <returns>Credit Profile</returns>
        [HttpGet("~/api/v1/customers/{id}/creditprofiles/{profileId}", Name = "GetCreditProfileByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCreditProfileByCustomerId(int id, int profileId)
        {
            if (id <= 0 || profileId <= 0)
                return BadRequest("Invalid Id");

            CreditProfile profile = _context.CreditProfile
                .Where(x => x.CustomerId == id && x.Id == profileId)
                .SingleOrDefault();

            return profile == null
                ? (ActionResult)NotFound("Account not found")
                : Ok(_mapper.Map<GetCreditProfileResponse>(profile));
        }

        /// <summary>
        /// Update credit profile
        /// </summary>
        /// <param name="id">Credit Profile ID</param>
        /// <param name="body">Update body</param>
        /// <returns>204 No Content</returns>
        [HttpPut("~/api/v1/customers/{id}/creditprofiles/{profileId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateCreditProfileById(int id, int profileId, [FromBody] UpdateCreditProfileRequest body)
        {
            if (id <= 0 || profileId <= 0)
                return BadRequest("Invalid Id");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreditProfile profile = _context.CreditProfile
                .Where(x => x.CustomerId == id && x.Id == profileId)
                .SingleOrDefault();

            if (profile == null)
                return NotFound("Account not found");

            if (profile.Balance + body.WithdrawalAmount > profile.LineOfCredit)
                return StatusCode(StatusCodes.Status403Forbidden, "Insufficient funds");

            profile.Balance += body.WithdrawalAmount;
            profile.ModifiedOn = DateTime.Now;
            profile.ModifiedBy = 1;

            _context.SaveChanges();

            return NoContent();
        }
    }
}