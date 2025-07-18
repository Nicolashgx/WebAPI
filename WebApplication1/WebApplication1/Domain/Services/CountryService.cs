﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.DAL.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Domain.Services
{
    public class CountryService : ICountryService

    {
        private readonly DataBaseContext _context;


        public CountryService(DataBaseContext context)
        {
            _context = context;
            
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
           

            try
            {
                country.id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country);

                await _context.SaveChangesAsync();

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }


        }

        public async Task<Country> DeleteCountryAsync(Guid id)

        {

            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country == null)
                {

                    return null;

                }

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }


        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country);

                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
         
            try
            {
                var countries = await _context.Countries.ToListAsync();

                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }


        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
       
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.id == id);
                var country1 = await _context.Countries.FindAsync(id);
                var country2 = await _context.Countries.FirstAsync(c => c.id == id);

                return country;



            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
    }
}
