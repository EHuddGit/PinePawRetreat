using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Models
{
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; }
        [Required]

        public Guid OwnerID { get; set; }
        public virtual OwnerModel Owner { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        [MaxLength (1)]
        public string Sex { get; set; }
        [Required]
        public string Age { get; set; }
        public string Color { get; set; }
        public float Weight { get; set; }
        public string DietaryRequirements { get; set; }
        public string MedicationRequirements { get; set; }
        public virtual List<PetBookingModel> PetBookingJoin { get; set; }
        public virtual List<VaccinationModel> Vaccinations { get; set; }



        public PetModel() 
        {
            PetID = Guid.NewGuid();
        }

    }
}