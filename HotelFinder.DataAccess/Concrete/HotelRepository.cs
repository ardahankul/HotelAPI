﻿using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbAccess())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbAccess())
            {
                var deletedHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(await deletedHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            using(var hotelDbContext = new HotelDbAccess())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbAccess())
            {
                return await hotelDbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbAccess())
            {
                //return hotelDbContext.Hotels.Find(name);
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbAccess())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();  
                return hotel;
            }
        }
    }
}
