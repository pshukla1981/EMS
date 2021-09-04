using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMA.Business.Factory.ViewModels;
using EMA.Data;

namespace EMA.Business.Factory.Repository
{
    public class HelpRepository
    {
        /// <summary>
        /// get the help text data by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HelpTextModel GetHelp(string key)
        {
            HelpTextModel model = new HelpTextModel();
            try
            {
                using (var db = new EMSEntities())
                {
                    var data = db.HelpTexts.Where(t => t.HelpTextKey == key).FirstOrDefault();
                    if(data != null)
                    {
                        model.Id = data.Id;
                        model.HelpTextKey = data.HelpTextKey;
                        model.HelpTextValue = data.HelpTextValue;
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return model;
        }
    }
}
