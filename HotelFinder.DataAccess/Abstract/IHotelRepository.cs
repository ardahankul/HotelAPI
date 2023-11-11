using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> GetHotelByName(string name);  
        Task<Hotel> AddHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(Hotel hotel);
        Task DeleteHotelById(int id);  

    }
}
