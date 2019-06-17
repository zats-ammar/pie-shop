using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethonysPieShop.Models.Interfaces
{
    public interface IPieRepository //repository class - single api that is open to the rest of the application which abstracts the pie implementation
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int id);
    }
}
