using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PinePawRetreat.ViewModels
{
    public class PetVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string NextStay { get; set; }
        [Required]
        public string Boarding_Ready { get; set; }
    }
}