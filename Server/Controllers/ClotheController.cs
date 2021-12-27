using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P7.Server.DB;
using P7.Shared;
using P7.Shared.Models;
namespace P7.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/Clothe
    public class ClotheController : Controller
    {
        public static List<Cloth> Clothes = new List<Cloth>
        {
            new Cloth(){Name = "hat" , Color = "Red" , Id = 1 , Price = 1000},
            new Cloth(){Name = "Shirt" , Color = "Blue" , Id = 2 , Price = 2000},
            new Cloth(){Name = "Pants" , Color = "Purple" , Id = 3 , Price = 3000}
        };


        [HttpGet]
        [Route("getAllClothes")]
        public List<Cloth> GetAllClothes() => ClotheController.Clothes;
        [HttpGet("getClothById/{id}")]
        public Cloth GetClothById(int id )
        {
            return ClotheController.Clothes.Where(cloth => cloth.Id == id).FirstOrDefault();
        }
        [HttpPost]
        [Route("addNewCloth")]
        public Cloth AddNewCloth(Cloth cloth)
        {
            var newId = ClotheController.Clothes.Last().Id + 1;
            var newCloth = new Cloth() { Name = cloth.Name, Color = cloth.Color, Id = newId, Price = cloth.Price };
            ClotheController.Clothes.Add(newCloth);
            return newCloth;
        }
        [HttpDelete]
        [Route("removeClothes")]
        public List<Cloth> RemoveCloth(int[] ids)
        {
            ClotheController.Clothes.RemoveAll(arg => ids.Contains(arg.Id));
            return ClotheController.Clothes;
        }
        [HttpPut("updateClothName")]
        // [Route("updateClothName")]
        // [HttpPut("updateClothName/{id}/{name}")]    rahe digare anjame in kar
        public Cloth UpdateClothName(int id , string name)
        {
            var clothe = Clothes.Where(cloth => cloth.Id == id).FirstOrDefault();
            var idx = Clothes.IndexOf(clothe);
            Clothes[idx] = clothe;
            //clothe.Name = name;
            return Clothes[idx];
        }
        [HttpPut]
        [Route("updateCloth")]
        public Cloth UpdateCloth(Cloth newClothe)
        {
            var idx = Clothes.IndexOf(newClothe);
            Clothes[idx] = newClothe;
            return Clothes[idx];
        }
        private readonly ClothProvider _provider;
        public ClotheController(ClothProvider provider)
        {
            this._provider = provider;
        }
        [HttpPost]
        [Route("addClothToDb")]
        public Cloth AddClothToDb(Cloth cloth)
        {
            this._provider.AddCloth(cloth);
            return cloth;
        }   
        [HttpGet]
        [Route("getAllClothesFromDb")]
        public List<Cloth> GetAllClothesFromDb()
        {
            List<Cloth> Clothes =  this._provider.GetAllClothes();
            return Clothes;
        }
        [HttpPut]
        [Route("UpdateClothInDb")]
        public void UpdateClothInDb(Cloth cloth)
        {
            this._provider.UpdateCloth(cloth);
        }
        [HttpDelete]
        [Route("DeleteFromDB")]
        public void DeleteFromDB(int id)
        {
            this._provider.DeleteCloth(id);
        }
        

    }
}
