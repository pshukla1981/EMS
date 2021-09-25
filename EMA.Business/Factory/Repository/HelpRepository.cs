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

        public int CountChars(string str,string character)
        {
            int Countter = 0;
            char[] arr = str.ToCharArray();
            foreach(var items in arr)
            {
                if(items.ToString() == character)
                {
                    Countter++;
                }
            }
            return Countter;
        }

        public string CountTotalChars(string str)
        {
            string output = string.Empty;
            int Countter = 1;
            char[] arr = str.ToCharArray();
            Dictionary<string, int> dist = new Dictionary<string, int>();
            foreach (var items in arr)
            {
                if (!dist.ContainsKey(items.ToString()))
                {
                    dist.Add(items.ToString(), 1);
                }
                else
                {
                    dist.Add(items.ToString(), Countter++);
                }
            }
            return output;
        }
    }
}
