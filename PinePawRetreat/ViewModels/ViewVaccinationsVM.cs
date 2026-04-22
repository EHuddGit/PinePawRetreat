using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PinePawRetreat.ViewModels
{
    public class ViewVaccinationsVM
    {
        public string PetID { get; set; }
        public List<VaccinationVM> Vaccinations { get; set; }
    }
}