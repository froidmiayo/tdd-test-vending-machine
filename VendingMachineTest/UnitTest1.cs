using System;
using ConsoleApp1;
using NUnit.Framework;

namespace VendingMachineTest
{
    [TestFixture]
    public class VendingMachineTests
    {
        private readonly Random _rnd = new Random();
        [Test]
        public void VendingMachineTests_ValidMoney_Should_ReturnTrue()
        {
            var data = new VendingMachine();

            var result =data.AcceptMoney(100);

            Assert.IsTrue(result);
        }
        [Test]
        public void VendingMachineTests_InvalidMoney_Should_ReturnFalse()
        {
            var data = new VendingMachine();

            var result =data.AcceptMoney(3);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void VendingMachineTests_SelectProduct_Should_ReturnSelectedProductType()
        {
            var v = new VendingMachine();
            var list = v.GetProducts();
            var data = list[_rnd.Next(0, list.Length - 1)];
            v.SelectProduct(data.Type);

            var result = v.GetSelectedProduct().Type;

            Assert.AreEqual(data.Type, result);
        }
        [Test]
        public void VendingMachineTests_SelectProduct_Should_ReturnSelectedProductPrice()
        {
            var v = new VendingMachine();
            var list = v.GetProducts();
            var data = list[_rnd.Next(0, list.Length - 1)];
            v.SelectProduct(data.Type);

            var result = v.GetSelectedProduct().Price;

            Assert.AreEqual(data.Price, result);
        }

        [Test]
        public void VendingMachineTests_CancelTransaction_Should_RefundMoney()
        {
            var data = new VendingMachine();
            data.AcceptMoney(100);
            data.AcceptMoney(50);
            data.AcceptMoney(.25m);
            
            var result = data.CancelOrder();

            Assert.AreEqual(150.25, result.Change);
            Assert.IsTrue(result.IsCancelled);
        }
        [Test]
        public void VendingMachineTests_SuccessfulOrder_Should_ReturnSelectedProduct()
        {
            var data = new VendingMachine();
            data.AcceptMoney(50);
            data.SelectProduct(ProductType.Soda); //Soda @ 45
         
            var result = data.OrderSelectedProduct();

            Assert.IsNotNull(result?.SelectedProduct);
            Assert.AreEqual(ProductType.Soda, result?.SelectedProduct?.Type);
        }
        [Test]
        public void VendingMachineTests_SuccessfulOrder_Should_ReturnChange()
        {
            var data = new VendingMachine();
            data.AcceptMoney(50);
            data.SelectProduct(ProductType.Soda); //Soda @ 45
         
            var result = data.OrderSelectedProduct();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Change);
        }
        [Test]
        public void VendingMachineTests_UnsuccessfulOrder_InsufficientFunds_ReturnNotSucceeded()
        {
            var data = new VendingMachine();
            data.AcceptMoney(40);
            data.SelectProduct(ProductType.Soda); //Soda @ 45
         
            var result = data.OrderSelectedProduct();

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotEmpty(result.Message);
        }
        [Test]
        public void VendingMachineTests_UnsuccessfulOrder_NoSelectedProduct_ReturnNotSucceeded()
        {
            var data = new VendingMachine();
            data.AcceptMoney(50);
            
            //NoSelected Product
            var result = data.OrderSelectedProduct();

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotEmpty(result.Message);
        }
    }
}