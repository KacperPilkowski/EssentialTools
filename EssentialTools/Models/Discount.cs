using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDecimal(decimal totalParam);
    }

    public class DefaltDiscountHelper : IDiscountHelper
    {
        private decimal discountSize;

        public DefaltDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDecimal(decimal totalParam)
        {
            return (totalParam -(discountSize/100m * totalParam));
        }
    }
}