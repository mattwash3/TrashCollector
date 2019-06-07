using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Weekly Pick Up Day")]
        public string WeeklyPickUp { get; set; }
        [Display(Name = "One Time Pick Up")]
        public string OneTimePickUp { get; set; }
        [Display(Name = "Suspend Pick Up Time Period")]
        public string SuspendPickUp { get; set; }
        [Display(Name = "Amount Due This Month")]
        public int PickUpTotalFees { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}