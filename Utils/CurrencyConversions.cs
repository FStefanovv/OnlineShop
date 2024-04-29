using EFCoreVezba.Enums;

namespace EFCoreVezba.Utils;

public static class CurrencyConversions {
    private static readonly double EUR2RSD = 117.5;
    private static readonly double EUR2USD = 1.09;
    private static readonly double USD2RSD = 107.6;

    public static double Convert(Currency sourceCurrency, Currency destinationCurrency, double amount){
        if (sourceCurrency == Currency.EUR && destinationCurrency == Currency.RSD)
            return amount * EUR2RSD;
        else if (sourceCurrency == Currency.EUR && destinationCurrency == Currency.USD)
            return amount * EUR2USD;
        else if (sourceCurrency == Currency.USD && destinationCurrency == Currency.RSD)
            return amount * USD2RSD;
        else if (sourceCurrency == Currency.RSD && destinationCurrency == Currency.EUR)
            return amount / EUR2RSD;
        else if (sourceCurrency == Currency.USD && destinationCurrency == Currency.EUR)
            return amount / EUR2USD;
        else if (sourceCurrency == Currency.RSD && destinationCurrency == Currency.USD)
            return amount / USD2RSD;
        else
            throw new ArgumentException("Invalid currency conversion.");
    }


}