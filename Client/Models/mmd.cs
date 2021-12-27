using System;
using System.ComponentModel.DataAnnotations;



namespace Models
{
    public class mmd
    {

        
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
        [Required ]
        public string Address {get; set;}
        [Required]
        public string PhoneNumber {get; set;}
    }

}