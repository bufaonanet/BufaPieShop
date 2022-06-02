using BufaPieShop.App.Models;
using System.Collections.Generic;

namespace BufaPieShop.App.ViewModes
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }       
    }
}
