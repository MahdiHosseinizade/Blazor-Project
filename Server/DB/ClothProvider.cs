using Microsoft.Extensions.Logging;
using P7.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P7.Shared.Models;
namespace P7.Server.DB
{
    public class ClothProvider
    {
        private readonly ClothDbContext _context;
        private readonly ILogger _logger;
        public ClothProvider(ClothDbContext context , ILoggerFactory logger)
        {
            this._context = context;
            this._logger = logger.CreateLogger("ClothProvider");
        }
        public void AddCloth(Cloth cloth)
        {
            var newId = 0;
            if (_context.Clothes.Any())
                newId = _context.Clothes.OrderBy(arg=> arg).Last().Id + 1;
            cloth.Id = newId;
            _context.Clothes.Add(cloth);
            _context.SaveChanges();
        }
        public List<Cloth> GetAllClothes()
        {
            // return null;
            return this.  _context.Clothes.ToList();
        }
        // public List<Cloth> getAllSportCloth()
        // {
        //     this._context.Clothes.ToList().Where(Cloth.Title)
        // }
        public void UpdateCloth(Cloth cloth)
        {
            this._context.Clothes.Update(cloth);
            _context.SaveChanges();
        }
        public void DeleteCloth(int id)
        {
            var Cloth=this._context.Clothes.Where(cloth=>cloth.Id==id).FirstOrDefault();
            _context.Clothes.Remove(Cloth);
            _context.SaveChanges();
        }
        
        
    }
}

