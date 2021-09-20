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
                        CountryDescription = t.CountryDescription,
                        CityList = db.tblCities.Where(x => x.CountryId == t.Id).Select(c => new CityModel
                        {
                            CityId = c.CityId,
                            CityName = c.CityName
                        }).ToList()
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
        /// <summary>
        /// this function is used to add/edit the country data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertUpdateCountry(CountryModel model)
        {
            string Result = string.Empty;
            try
            {
                using (var db = new EMSEntities())
                {
                    if(model.Id == 0)
                    {
                        #region Add Country
                        tblCountry obj = new tblCountry();
                        obj.CountryName = model.CountryName;
                        obj.CountryDescription = model.CountryDescription;
                        db.tblCountries.Add(obj);
                        db.SaveChanges();
                        #endregion
                        Result = "Country added successfully";
                    }
                    else
                    {
                        #region Update Country
                        tblCountry obj = new tblCountry();
                        obj = db.tblCountries.Where(a => a.Id == model.Id).FirstOrDefault();
                        if(obj != null)
                        {
                            obj.CountryName = model.CountryName;
                            obj.CountryDescription = model.CountryDescription;
                            db.SaveChanges();
                        }
                        #endregion
                        Result = "Country updated successfully";
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        /// <summary>
        /// get the list of countries
        /// </summary>
        /// <returns></returns>
        public List<CountryModel> GetList()
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
