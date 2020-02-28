using System.Collections.Generic;

namespace ConsoleApp1
{
    public class BillsAndCoins
    {
        public  decimal TotalValue { get; set; }
        public BillsAndCoins(IReadOnlyDictionary<ValidMoneyType, int> money)
        { 
            TotalValue = 0;
           money.TryGetValue(ValidMoneyType.HundredDollar, out int totalHundredDollarAmount);
           money.TryGetValue(ValidMoneyType.FiftyDollar, out int totalFiftyDollarAmount);
           money.TryGetValue(ValidMoneyType.TwentyDollar, out int totalTwentyDollarAmount);
           money.TryGetValue(ValidMoneyType.TenDollar, out int totalTenDollarAmount);
           money.TryGetValue(ValidMoneyType.FiveDollar, out int totalFiveDollarAmount);
           money.TryGetValue(ValidMoneyType.OneDollar, out int totalOneDollarAmount);
           money.TryGetValue(ValidMoneyType.FiftyCent, out int totalFiftyCentAmount);
           money.TryGetValue(ValidMoneyType.TwentyFiveCent, out int totalTwentyFiveCentAmount);

           TotalValue += (totalHundredDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.HundredDollar]);
           TotalValue += (totalFiftyDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.FiftyDollar]);
           TotalValue += (totalTwentyDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.TwentyDollar]);
           TotalValue += (totalTenDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.TenDollar]);
           TotalValue += (totalFiveDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.FiveDollar]);
           TotalValue += (totalOneDollarAmount * Constant.ValidMoneyValues[ValidMoneyType.OneDollar]);
           TotalValue += (totalFiftyCentAmount * Constant.ValidMoneyValues[ValidMoneyType.FiftyCent]);
           TotalValue += (totalTwentyFiveCentAmount * Constant.ValidMoneyValues[ValidMoneyType.TwentyFiveCent]);
        }
    }


    public enum ValidMoneyType
    {
        HundredDollar,FiftyDollar,TwentyDollar,TenDollar,FiveDollar,OneDollar,FiftyCent,TwentyFiveCent
    }
}
