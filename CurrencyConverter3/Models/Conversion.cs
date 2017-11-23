using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter3.Models
{
    public class Conversion
    {
        //required, must be >0
        [Required]
        public double OriginalAmount { get; set; }

        [Required]
        public Currency OriginalCurrency { get; set; }

        [Required]
        public Currency TargetCurrency { get; set; }
    }
}
