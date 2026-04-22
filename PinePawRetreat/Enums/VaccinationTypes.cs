using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Enums
{
    public enum VaccinationTypes
    {
        None = 0,
        [Display(Name = "Bordetella")]
        Bortella = 1,
        [Display(Name = "DHPP (Distemper, Hepatitis, Parvo)")]
        DHPP, //(Distemper, Hepatitiis, Parainfluenza, parvovirus,)
        [Display(Name = "FVRCP (Feline Core Vaccine)")]
        FVRCP,// (Feline Viral Rhinotracheitis, Calicivirus & Panleukopenia)
        [Display(Name = "Rabies")]
        Rabies,
        [Display(Name = "Canine Influenza")]
        Canine_Influenza,
        [Display(Name = "Leptospirosis")]
        Leptospirosis,
    }
}