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
        [Required]
        public string petID { get; set; }
        [Required]
        [MaxLength(1,ErrorMessage = "Please Indicate Sex with F or M")]
        public string Sex { get; set; }
        [Required]
        public string Color { get; set; }
        public string DietaryRequirements { get; set; }
        public string MedicationRequirements { get; set; }
    }
}