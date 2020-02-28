using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class VendingMachine
    {
        private Dictionary<ValidMoneyType, int> TotalAcceptedMoney { get; set; }
        private Product SelectedProduct { get; set; }

        public VendingMachine()
        {
            TotalAcceptedMoney = new Dictionary<ValidMoneyType, int>();
        }
        public Product[] GetProducts()
        {
            return Constant.ProductList;
        }

        public Product GetSelectedProduct()
        {
            return SelectedProduct;
        }

        public bool AcceptMoney(decimal money)
        {
            return IsMoneyValid(Math.Round(money, 2), out ValidMoneyType key) && ProcessMoney(key);
        }

        private bool IsMoneyValid(decimal money, out ValidMoneyType key)
        {
            if (Constant.ValidMoneyValues.ContainsValue(money))
            {
                key = Constant.ValidMoneyValues.First(x => x.Value.Equals(money)).Key;
                return true;
            }
            key = ValidMoneyType.OneDollar;
            return false;
        }
        private bool ProcessMoney(ValidMoneyType key)
        {
            if (TotalAcceptedMoney.ContainsKey(key))
            {
                TotalAcceptedMoney[key] = TotalAcceptedMoney[key] + 1;
            }
            else
            {
                TotalAcceptedMoney.Add(key,1);
            }

            return true;
        }

        public void SelectProduct(ProductType product)
        {
            SelectedProduct = GetProducts().First(x => x.Type.Equals(product));
        }

        public OrderResult OrderSelectedProduct()
        {
            if (HasNoSelectedProduct)
            {
                return new OrderResult(false,Constant.ErrorMessageForNoProductSelected);
            }

            if (IsMoneyNotEnough)
            {
                return new OrderResult(false,Constant.ErrorMessageForNotEnoughMoney);
            }
            return  new OrderResult(true,SelectedProduct, AcceptedMoneyValue);
        }

        public OrderResult CancelOrder()
        {
            var result = new OrderResult(false,Constant.ErrorMessageForCancelled)
            {
                IsCancelled =  true
            };
            RemoveSelectedProduct();
            result.ReturnCancelledTransactionMoney(TotalAcceptedMoney);
            return result;
        }

        private bool IsMoneyNotEnough => AcceptedMoneyValue < (SelectedProduct?.Price ?? 0);
        private bool HasNoSelectedProduct => SelectedProduct == null;
        private decimal AcceptedMoneyValue
        {
            get
            {
                if (TotalAcceptedMoney.Any())
                {
                    return  new BillsAndCoins(TotalAcceptedMoney).TotalValue;
                }
                return 0;
            }
        }

        private void RemoveSelectedProduct()
        {
            SelectedProduct = null;
        }

    }
}