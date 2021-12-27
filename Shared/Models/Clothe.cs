// using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P7.Shared.Models
{
    public class Cloth
    {
        [Required]
        public int Price {get ; set ;}
        [Required]
        public string Name{get ;set ;}
        [Required]
        public int Id {get ; set ;}
        [Required]
        public string Color {get ;set ;}
        [Required]
        public string Address{get;set;}
        [Required]
        public string description { get; set; }
        [Required]
        public int Left { get; set; }
        public int Number;
        public override string ToString()
        {
            return $"{this.Name}, {this.Price}, {this.Id}, {this.Color}";
            
        }
        public override int GetHashCode()
        {
            return this.Id ;
        }
        public override bool Equals(object obj)
        {
            var otherCloth = obj as Cloth;
            if (obj is null) return false;
            return this.Id == otherCloth.Id;
        }
    }
}