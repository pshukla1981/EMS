using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMA.Business.Factory.ViewModels
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryDescription { get; set; }
    }
}
