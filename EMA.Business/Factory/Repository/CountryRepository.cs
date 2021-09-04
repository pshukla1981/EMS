using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMA.Business.Factory.ViewModels;
using EMA.Data;

namespace EMA.Business.Factory.Repository
{
    public class CountryRepository
    {
        /// <summary>
        /// get list of countries
        /// </summary>
        /// <returns></returns>
        public List<CountryModel> GetCountryList()
        {
            List<CountryModel> countries = new List<CountryModel>();
            try
            {
                using (var db = new EMSEntities())
                {
                    var lst = db.tblCountries.Select(t => new CountryModel
                    {
                        Id = t.Id,
                        CountryName = t.CountryName,
                        CountryDescription = t.CountryDescription
                    }).ToList();
                    countries = lst;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return countries;
        }
    }
}
