using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator: IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int counter = 0; 

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(
                string.Format("Utworzono egzemplarz {0}", counter++));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDecimal(products.Sum(p => p.Price));
        }
    }
}