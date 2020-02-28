using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class Constant
    {
        public  static Product[] ProductList =
        {
            new Product(ProductType.Coke, 25),
            new Product(ProductType.Pepsi, 35),
            new Product(ProductType.Soda, 45),
            new Product(ProductType.ChocolateBar, 20.25m),
            new Product(ProductType.ChewingGum, 10.5m),
            new Product(ProductType.BottledWater, 15),
        };

        public static string ErrorMessageForNoProductSelected = "No Product Selected!";
        public static string ErrorMessageForNotEnoughMoney = "Insufficient Funds";
        public static string ErrorMessageForCancelled = "Cancelled Transaction";

        public static Dictionary<ValidMoneyType, decimal> ValidMoneyValues = new Dictionary<ValidMoneyType, decimal>()
        {
            { ValidMoneyType.HundredDollar, 100},
            { ValidMoneyType.FiftyDollar, 50},
            { ValidMoneyType.TwentyDollar, 20},
            { ValidMoneyType.TenDollar, 10},
            { ValidMoneyType.FiveDollar, 5},
            { ValidMoneyType.OneDollar, 1},
            { ValidMoneyType.FiftyCent, .5m},
            { ValidMoneyType.TwentyFiveCent, .25m},

        };
    }
}
