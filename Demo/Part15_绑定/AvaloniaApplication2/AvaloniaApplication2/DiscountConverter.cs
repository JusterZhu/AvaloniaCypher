using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaApplication2;

public class DiscountConverter : IMultiValueConverter
{
    //<!--结算金额 = 商品价格 * 商品数量 * 折扣 + 优惠券满100减5-->
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count > 2)
        {
            //加上判断

            if (values[0] is null || values[1] is null || values[2] is null)
            {
                return null;
            }

            var priceValid =  double.TryParse(values[0].ToString(),out double price);
            var numberValid =  double.TryParse(values[1].ToString(),out double number);
            var discountRateValid =  double.TryParse(values[2].ToString(),out double discountRate);

            if (!priceValid || !numberValid || !discountRateValid)
            {
                return null;
            }
            
            return Math.Round(price * number * discountRate, 2).ToString();
        }

        return null;
    }
}