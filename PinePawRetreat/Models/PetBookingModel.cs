using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Models
{
    public class PetBookingModel
    {
        [Key]
        public Guid PetBookingID { get; set; }
        [Required]
        public Guid PetID { get; set; }
        [Required]
        public Guid BookingID { get; set; }
        public virtual PetModel Pet { get; set; }
        public virtual BookingModel Booking { get; set; }
        public PetBookingModel()
        {
            PetBookingID = Guid.NewGuid();
        }

        public PetBookingModel(PetModel pet, BookingModel booking) : this()
        {
            Pet = pet;
            Booking = booking;
        }
    }
}