using PinePawRetreat.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.ViewModels
{
    public class VaccinationVM
    {
        [Required]
        public VaccinationTypes VaccName { get; set; }
        [Required]
        public DateTime DatePerformed { get; set; }
        [Required]
        public DateTime DateDue { get; set; }
        public string VerifiedStatus { get; set; }
    }
}