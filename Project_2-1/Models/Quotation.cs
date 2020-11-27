namespace PriceQuotation.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;


    public class Quotation
    {
        [Required(ErrorMessage = "Please entera subtotal amount.")]
        [Range(0.01, 1000000, ErrorMessage = "Subtotal amount must be greater than 0.")]
        [Display(Name = "Subtotal amount")]

        public double? Subtotal { get; set; }

        [Required(ErrorMessage = "Please entera discount percent")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100.")]
        [Display (Name ="Discount percent")]
        public double? DiscountPercent { get; set; }

        public double CalculateDiscount()

        {
            if (Subtotal.HasValue && DiscountPercent.HasValue)
            {
                return Subtotal.Value * (DiscountPercent.Value / 100);

            }
           
                return 0;
            }

            public double CalculateTotal()

            {

          //    if (Subtotal.HasValue)
          //   { 
          //   return Subtotal.Value - CalculateDiscount();
          //    }
          //    else
          //    {
          //  return 0;
           // }

            return Subtotal.HasValue ? Subtotal.Value - CalculateDiscount() : 0;
        }
    }
}
