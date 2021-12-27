// object new


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P7.Shared.Models
{
    public class Shoes
    {
        public string Name{get;set;}
        public int Price{get;set;}
        public string Color{get;set;}

        public override string ToString()
        {
            return $"{this.Color},{this.Price},{this.Name}";
        }


        public override int GetHashCode()
        {
            return this.Price;
        }


        public override bool Equals(object obj)
        {
            var otherShoes = obj as Shoes;
            if (obj is null) return false;
            return this.Price == otherShoes.Price;
        }
    }
}