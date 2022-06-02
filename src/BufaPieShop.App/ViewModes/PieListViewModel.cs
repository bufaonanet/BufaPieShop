using BufaPieShop.App.Models;
using System.Collections.Generic;

namespace BufaPieShop.App.ViewModes
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
