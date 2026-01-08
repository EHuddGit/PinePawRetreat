using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PinePawRetreat.Enums;

namespace PinePawRetreat.Models
{
    public class VaccinationModel
    {
        [Key]
        public Guid VaccID { get; set; }
        [Required]
        public Guid PetID { get; set; }
        [Required]
        public VaccinationTypes VaccName { get; set; }
        [Required]
        public DateTime DatePerformed { get; set; }
        [Required]
        public DateTime DateDue { get; set; }
        public virtual PetModel Pet { get; set; }

        public VaccinationModel()
        {
            VaccID = Guid.NewGuid();
        }
    }
}