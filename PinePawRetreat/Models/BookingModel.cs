using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Models
{
    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; }
        [Required]
        public DateTime BookingStartTime {  get; set; }
        [Required]
        public DateTime BookingEndTime {  get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime? CheckedInTime {  get; set; }
        public DateTime? CheckedOutTime { get; set; }
        public string CheckedInBy { get; set; }
        public string CheckedOutBy { get; set; }
        public List<PetBookingModel> PetBookingJoin { get; set; }
        [Required]
        public OwnerModel Owner { get; set; }

        public BookingModel() 
        {
            BookingID = Guid.NewGuid();
        }
        

    }
}