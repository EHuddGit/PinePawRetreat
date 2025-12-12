using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PinePawRetreat.Models
{
    public class ContactModel
    {
        [Key]
        public Guid ContactID { get; set; }
        [Required]
        public string NameFirst { get; set; }
        [Required]
        public string NameLast { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SubmittedAt { get; set; }
        public ContactModel() 
        {
            ContactID = Guid.NewGuid();
            SubmittedAt = DateTime.Now;
        }

    }
}