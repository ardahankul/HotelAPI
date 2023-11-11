using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }

       
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            
            if (hotel != null) {
                return Ok(hotel);   
            }
            
            return NotFound(); 
        }

        [HttpGet("{name}")]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await  _hotelService.GetHotelByName(name);

            if (hotel != null)
            {
                return Ok(hotel);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
        {
            var createdHotel = await _hotelService.AddHotel(hotel);
            return CreatedAtAction("Get", new {id  = createdHotel.Id}, createdHotel); //status code: 201 + data

            /*
             * [ApiController] annotation checks the request valid then returns bad request.
             * So we dont need to check ModelState.IsValid
             */
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Hotel hotel)
        {
            if(await _hotelService.GetHotelById(hotel.Id) != null)
            {
                var updatedHotel = await _hotelService.UpdateHotel(hotel);
                return Ok(updatedHotel);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotelById(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
