using NUnit.Framework;
using System;
 

namespace Capgemini.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            BankAccountTest account = new BankAccountTest(1000);
            account.Deposit(500);
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            BankAccountTest account = new BankAccountTest(1000);

            var ex = Assert.Throws<Exception>(() => account.Deposit(-200));
            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            BankAccountTest account = new BankAccountTest(1000);
            account.Withdraw(400);
            Assert.AreEqual(600, account.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            BankAccountTest account = new BankAccountTest(500);

            var ex = Assert.Throws<Exception>(() => account.Withdraw(800));
            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
