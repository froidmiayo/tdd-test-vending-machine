using System.Collections.Generic;

namespace ConsoleApp1
{
    public class OrderResult
    {
        public  Product SelectedProduct { get; set; }
        public  string Message { get; set; }
        public OrderResult(bool succeeded, Product product, decimal acceptedMoney)
        {
            Succeeded = succeeded;
            SelectedProduct = product;
            Change = acceptedMoney - product.Price;
        }

        public OrderResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public  bool? IsCancelled { get; set; }
        public  decimal? Change { get; set; }
        public  Dictionary<ValidMoneyType, int> ReturnedMoney { get; set; }

        public void ReturnCancelledTransactionMoney( Dictionary<ValidMoneyType, int> money)
        {
            ReturnedMoney = money;
            Change = new BillsAndCoins(ReturnedMoney).TotalValue;
        }
    }
}