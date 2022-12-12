using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Api.Controllers
{
    [ApiController]
    [Route("phone")]
    public class PhonesController : Controller
    {
        readonly IPhoneService _phoneService;
        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [Authorize]
        [HttpGet("/search/{search}")]
        public async Task<IActionResult> GetPhones(string search)
        {
            List<Phone> result = await _phoneService.SearchPhone(search);
            if (result.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Phone result = _phoneService.GetByID(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PhoneDTO phone)
        {
            try
            {
                Brand brandToAdd = new()
                {
                    BrandName = phone.BrandName
                };
                Phone phoneToAdd = new()
                {
                    Type = phone.Type,
                    Stock = phone.Stock,
                    Price = phone.Price,
                    Description = phone.Description,
                    Brand = brandToAdd
                };
                _phoneService.AddPhone(phoneToAdd);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
