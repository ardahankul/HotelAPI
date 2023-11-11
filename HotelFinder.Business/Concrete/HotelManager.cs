using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }


        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            return await _hotelRepository.AddHotel(hotel);    
        }

        public async Task DeleteHotelById(int id)
        {
            await _hotelRepository.DeleteHotelById(id);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            if (id > 0) { 
                return await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id can not be less then one(1)");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}
