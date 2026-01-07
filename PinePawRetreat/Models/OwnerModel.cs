using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Models
{
    public class OwnerModel
    {
        [Key]
        public Guid OwnerID { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerPhoneNumber { get; set; }
        public string OwnerEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }

        public virtual List<PetModel> Pets { get; set; }
        public virtual List<BookingModel> Bookings { get; set; }

        public OwnerModel ()
        {
            OwnerID = Guid.NewGuid();
        }

    }
}