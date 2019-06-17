using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethonysPieShop.Models.Context;
using BethonysPieShop.Models.Interfaces;

namespace BethonysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbContext.Pies;
        }

        public Pie GetPieById(int id)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.Id == id);
        }
    }
}
