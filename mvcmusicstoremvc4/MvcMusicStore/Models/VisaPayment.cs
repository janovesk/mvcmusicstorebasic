using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MvcMusicStore.Models
{
    public class VisaPayment
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name of credit card holder")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Expiry month")]
        public string ExpiryMonth { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Expiry year")]
        public string ExpiryYear { get; set; }
       
    }
}