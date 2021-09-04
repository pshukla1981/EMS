using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EMA.Business.Factory.ViewModels;
using EMA.Data;


namespace EMA.Business.Factory.Repository
{
    public class CandidateRepository
    {
        /// <summary>
        /// get list of candidate names 
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public List<string> GetCandidate(string term)
        {
            List<string> lst = new List<string>();
            try
            {
                using (var db = new EMSEntities())
                {
                    lst = db.sp_GetCandidateNames(term).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return lst;
        }

    }
}
